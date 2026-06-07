using Microsoft.AspNetCore.Mvc;
using task1.Data;
using task1.Models;
using task1.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace task1.Controllers;

[Authorize]
public class ChatController : Controller
{
    private readonly ApplicationDbContext _context;
    public ChatController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var viewModel = new ChatViewModel
        {
            Rooms = _context.Rooms.ToList(),
            Messages = _context.Messages.OrderByDescending(m => m.SentAt).ToList(),
            Users = _context.Users.ToList()
        };

        return View(viewModel);
    }
}

