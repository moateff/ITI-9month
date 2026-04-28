using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _env;

    public HomeController(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IActionResult Index()
    {
        ViewBag.EnvironmentName = _env.EnvironmentName;
        ViewBag.WebRoot = _env.WebRootPath;

        return View();
    }
}