using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carService;

        public CarsController(ICarsService carsService)
        {
            _carService = carsService;
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _carService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Car Get(int id)
        {
            return _carService.GetCarById(id);
        }

        [HttpPost]
        public bool Post([FromBody] Car car)
        {
            return _carService.AddCar(car);
        }

        [HttpDelete]
        public bool Delete(int carId)
        {
            return _carService.Remove(carId);
        }

    }
}
