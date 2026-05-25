using Xunit;
using CarsApp;
using System;
using System.Text.RegularExpressions;

namespace CarAppTests
{
    public class CarTests
    {
        [Fact]
        public void Brake_TypeBMWVelocity200_Velocity185()
        {
            var car = new Car
            {
                Type = CarType.BMW,
                Velocity = 200
            };

            var expectedResult = 185;

            car.Brake();

            Assert.Equal(expectedResult, car.Velocity);
        }

        [Fact]
        public void Stop_Velocity200_Velocity0()
        {
            var car = new Car
            {
                Velocity = 200
            };

            var expectedResult = 0;

            car.Stop();

            Assert.Equal(expectedResult, car.Velocity);
        }

        [Fact]
        public void TwoCars_DifferentInstancesDifferentState_Velocity0()
        {
            var car1 = new Car
            {
                Velocity = 100
            };

            var car2 = new Car
            {
                Velocity = 200
            };

            Assert.NotSame(car1, car2);
        }

        [Fact]
        public void Accelerate_TypeHonda_ThrowsException()
        {
            var car = new Car
            {
                Type = CarType.Honda
            };

            Assert.Throws<NotImplementedException>(() => car.Accelerate());
        }

        [Fact]
        public void GetDirection_DrivingModeReverse_DirectionReverse()
        {
            var car = new Car
            {
                DrivingMode = DrivingMode.Reverse
            };

            var expectedResult = "Rev";

            var result = car.GetDirection();

            Assert.StartsWith(expectedResult, result);
        }

        [Fact]
        public void GetDirection_DrivingModeForward_DirectionForward()
        {
            var car = new Car
            {
                DrivingMode = DrivingMode.Forward
            };

            var pattern = new Regex("^Reverse$");

            var result = car.GetDirection();

            Assert.DoesNotMatch(pattern, result);
        }
    }
}