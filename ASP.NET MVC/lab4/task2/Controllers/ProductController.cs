using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task2.Models;

namespace task2.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View(ProductList.Products);
    }
}