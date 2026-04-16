using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task2.Models;

namespace task2.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ShowDetails(User user)
    {
        ViewBag._user = user;
        return View();
    }
}