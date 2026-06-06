
using Microsoft.AspNetCore.SignalR;
using task1.Models;

public class OrderHub : Hub
{
    private readonly AppDbContext _context;

    public OrderHub(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        await Clients.All.SendAsync("OrderCreated", order);
    }
}