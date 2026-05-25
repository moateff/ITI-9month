using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using CarAPI.Entities;
using CarAPI.Services_BLL;

namespace CarsAPITests
{
    public class CarsServiceTests
    {
        private readonly Mock<IPaymentService> _paymentServiceMock;
        private readonly Mock<ICarsRepository> _carsRepositoryMock;
        private readonly CarsService _carsService;

        public CarsServiceTests()
        {
            _paymentServiceMock = new Mock<IPaymentService>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _carsService = new CarsService(_carsRepositoryMock.Object, _paymentServiceMock.Object);
        }

        [Fact]
        public void GetAll_AllExistingCars_ReturnsCarsFromRepository()
        {
            // Arrange
            var expectedCars = new List<CarAPI.Entities.Car>
            {
                new Car(1, CarType.Audi, 100),
                new Car(2, CarType.BMW, 150)
            };
            _carsRepositoryMock.Setup(r => r.GetAllCars()).Returns(expectedCars);

            // Act
            var result = _carsService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCars.Count, result.Count);
            Assert.Equal(expectedCars, result);
            _carsRepositoryMock.Verify(r => r.GetAllCars(), Times.Once);
        }

        [Fact]
        public void GetCarById_ExistingCar_ReturnsCarFromRepository()
        {
            // Arrange
            var expectedCar = new Car(1, CarType.Audi, 100);
            _carsRepositoryMock.Setup(r => r.GetCarById(1)).Returns(expectedCar);

            // Act
            var result = _carsService.GetCarById(expectedCar.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCar, result);
            _carsRepositoryMock.Verify(r => r.GetCarById(expectedCar.Id), Times.Once);
        }

        [Fact]
        public void AddCar_ExistingCar_ReturnsTrue()
        {
            // Arrange
            var newCar = new Car(1, CarType.Audi, 100);
            _carsRepositoryMock.Setup(r => r.AddCar(newCar)).Returns(true);
            _carsRepositoryMock.Setup(r => r.GetCarById(newCar.Id)).Returns(newCar);

            // Act
            var result = _carsService.AddCar(newCar);
            var existingCar = _carsService.GetCarById(newCar.Id);

            // Assert
            Assert.True(result);
            Assert.Equal(newCar, existingCar);
            _carsRepositoryMock.Verify(r => r.AddCar(newCar), Times.Once);
        }
    }
}