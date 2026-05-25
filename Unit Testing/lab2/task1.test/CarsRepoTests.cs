using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using Moq;

namespace CarsAPITests
{
    public class CarsRepoTests
    {
        private readonly Mock<InMemoryContext> _contextMock;
        private readonly CarsRepository _carsRepository;

        public CarsRepoTests()
        {
            _contextMock = new Mock<InMemoryContext>();
            _carsRepository = new CarsRepository(_contextMock.Object);
        }

        [Fact]
        public void GetAllCars_AllExistingCars_ReturnsCarsFromContext()
        {
            // Arrange
            var expectedCars = new List<Car>
            {
                new Car(1, CarType.Audi, 100),
                new Car(2, CarType.BMW, 150)
            };
            _contextMock.Setup(c => c.Cars).Returns(expectedCars);
            
            // Act
            var result = _carsRepository.GetAllCars();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCars.Count, result.Count);
            Assert.Equal(expectedCars, result);

            
        }

        [Fact]
        public void GetCarById_ExistingCar_ReturnsCarFromContext()
        {
            // Arrange
            var expectedCar = new Car(1, CarType.Audi, 100);
            _contextMock.Setup(c => c.Cars).Returns(new List<Car> { expectedCar });

            // Act
            var result = _carsRepository.GetCarById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCar, result);
        }

        [Fact]
        public void AddCar_ExistingCar_ReturnsTrue()
        {
            // Arrange
            var newCar = new Car(1, CarType.Audi, 100);
            _contextMock.Setup(c => c.Cars).Returns(new List<Car>());

            // Act
            var result = _carsRepository.AddCar(newCar);
            var existingCars = _carsRepository.GetCarById(newCar.Id);

            // Assert
            Assert.True(result);
            Assert.Equal(newCar, existingCars);
        }
    }
}