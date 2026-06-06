
using Microsoft.AspNetCore.Mvc;

public class OrderController : Controller
{
    private readonly AppDbContext _context;
    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Orders.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Delete(int id)
    { 
        var order = _context.Orders.Find(id);

        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}