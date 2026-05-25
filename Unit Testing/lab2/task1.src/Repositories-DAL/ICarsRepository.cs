using CarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Repositories_DAL
{
    public interface ICarsRepository
    {
        List<Car> GetAllCars();
        Car GetCarById(int id);
        bool AddCar(Car car);
        bool Remove(int carId);
    }
}