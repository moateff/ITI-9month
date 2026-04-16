using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers;

public class ProductController : Controller
{
    public IActionResult ShowProductDetails(string Name, string Picture, double Price, string Description) 
    {
        ViewData["Name"] = Name;
        ViewData["Picture"] = Picture;
        ViewData["Price"] = Price;
        ViewData["Description"] = Description;

        return View("ProductDetails");
    }
}


// /Product/ShowProductDetails?name=Almond%20Blossom&picture=vincent.jpg&price=1000&description=Large%20blossom%20branches%20like%20this%20against%20a%20blue%20sky%20were%20one%20of%20Van%20Gogh%E2%80%99s%20favourite%20subjects.%20Almond%20trees%20flower%20early%20in%20the%20spring%20making%20them%20a%20symbol%20of%20new%20life.