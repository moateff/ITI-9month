using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers;

public class CarController : Controller
{
    public IActionResult GetAllCars()
    {
        return View(CarList.Cars);
    }

    public IActionResult SelectCarById(int Num)
    {
        var _car = CarList.Cars.Find(x => x.Num == Num);

        if (_car == null) return NotFound();

        return View(_car);
    }

    public IActionResult CreateNewCar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateNewCar(Car car)
    {
        CarList.Cars.Add(new Car(){
            Num = ++CarList.Count, 
            Color = car.Color, 
            Model = car.Model, 
            Manfacture = car.Manfacture
        });
        return RedirectToAction("GetAllCars");
    }

    public IActionResult EditCar(int Num)
    {
        var _car = CarList.Cars.Find(x => x.Num == Num);

        if (_car == null) return NotFound();

        return View(_car);
    }

    [HttpPost]
    public IActionResult EditCar(Car car)
    {
        var _car = CarList.Cars.Find(x => x.Num == car.Num);

        if (_car == null) return NotFound();

        _car.Color = car.Color;
        _car.Model = car.Model;
        _car.Manfacture = car.Manfacture;

        return RedirectToAction("GetAllCars");
    }

    public IActionResult DeleteCar(int Num)
    {
        var _car = CarList.Cars.Find(x => x.Num == Num);

        if (_car == null) return NotFound();

        CarList.Cars.Remove(_car);
        
        return RedirectToAction("GetAllCars");
    }
}
