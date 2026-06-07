using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using task1.Models;
using task1.Data;

namespace task1.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;

    public ChatHub(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public override async Task OnConnectedAsync()
    {
        var user = await _userManager.GetUserAsync(Context.User);

        if (user != null)
        {
            await Clients.All.SendAsync("connected", user.Email);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var user = await _userManager.GetUserAsync(Context.User);

        if (user != null)
        {
            await Clients.All.SendAsync("disconnected", user.Email);
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task CreateRoom(string roomName)
    {
        var room = new Room
        {
            Name = roomName
        };

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        var user = await _userManager.GetUserAsync(Context.User);

        await Clients.All.SendAsync("createroom", user!.Email, room.Id, room.Name);
    }

    public async Task DeleteRoom(Guid roomId)
    {
        var room = await _context.Rooms.FindAsync(roomId);

        if (room == null) return;

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        var user = await _userManager.GetUserAsync(Context.User);

        await Clients.All.SendAsync("deleteroom", user!.Email, room.Id, room.Name);
    }

    public async Task JoinRoom(Guid roomId)
    {
        var room = await _context.Rooms.FindAsync(roomId);
        if (room == null) return;

        var user = await _userManager.GetUserAsync(Context.User);

        await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());

        await Clients.Group(room.Id.ToString())
            .SendAsync("joinroom", user!.Email, room.Name);
    }

    public async Task SendGroupMessage(Guid roomId, string message)
    {
        var room = await _context.Rooms.FindAsync(roomId);
        if (room == null) return;

        var user = await _userManager.GetUserAsync(Context.User);

        await Clients.Group(room.Id.ToString())
            .SendAsync("groupmessage", user!.Email, room.Name, message);
    }

    public async Task SendPublicMessage(string message)
    {
        var user = await _userManager.GetUserAsync(Context.User);

        await Clients.All.SendAsync("publicmessage", user!.Email, message);
    }

    public async Task SendPrivateMessage(string receiverEmail, string message)
    {
        var sender = await _userManager.GetUserAsync(Context.User);

        var receiver = _context.Users.FirstOrDefault(u => u.Email == receiverEmail);
        if (receiver == null) return;

        await Clients.User(receiver.Id.ToString())
            .SendAsync("privatemessage", sender!.Email, message);
    }
}