using CarsApp;
using System.Collections.Generic;
using Xunit;

namespace CarAppTests
{
    public class CarStoreTests
    {
        [Fact]
        public void GetAllStoreCars_SameCars_Same()
        {
            //Arrange
            var c1 = new Car();
            var c2 = new Car();
            var c3 = new Car();

            var carStore1 = new CarStore(new List<Car>() { c1, c2, c3 });
            var carStore2 = new CarStore(new List<Car>() { c1, c2, c3 });

            //Assert
            Assert.Equal(carStore1.Cars, carStore2.Cars);
        }

        [Fact]
        public void GetAllStoreCars_ValidCars_True()
        {
            //Arrange
            var c1 = new Car();
            var c2 = new Car();
            var c3 = new Car();

            var carStore = new CarStore(new List<Car>() { c1, c2, c3 });

            //Assert
            Assert.All(carStore.Cars, car => Assert.NotNull(car));
        }
    }
}