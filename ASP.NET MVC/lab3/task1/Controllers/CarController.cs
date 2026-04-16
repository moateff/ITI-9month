using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers;

public class CarController : Controller
{
    public IActionResult GetAllCars()
    {
        ViewBag.cars = CarList.Cars;
        return View();
    }

    public IActionResult SelectCarById(int Num)
    {
        ViewBag.car = CarList.Cars.Find(x => x.Num == Num);
        return View();
    }

    public IActionResult CreateNewCar()
    {
        return View();
    }

    public IActionResult AddNewCar(string Color, string Model, string Manfacture)
    {
        CarList.Cars.Add(new Car(){
            Num = ++CarList.Count, 
            Color = Color, 
            Model = Model, 
            Manfacture = Manfacture
        });
        return RedirectToAction("GetAllCars");
    }

    public IActionResult EditCar(int Num)
    {
        ViewBag.car = CarList.Cars.Find(x => x.Num == Num);
        return View();
    }

    public IActionResult DeleteCar(int Num)
    {
        CarList.Cars.Remove(CarList.Cars.Find(x => x.Num == Num));
        
        return RedirectToAction("GetAllCars");
    }

    public IActionResult UpdateCar(int Num, string Color, string Model, string Manfacture)
    {
        var car = CarList.Cars.Find(x => x.Num == Num);

        car.Color = Color;
        car.Model = Model;
        car.Manfacture = Manfacture;

        return RedirectToAction("GetAllCars");
    }
}
