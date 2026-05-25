using MyConsoleApp;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("");

            // Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public void Add_OneNumber_ReturnsThatNumber()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("5");

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Add_TwoNumbers_ReturnsTheirSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("3,4");

            // Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Add_UnknownNumberOfNumbers_ReturnsTheirSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1,2,3,4,5");

            // Assert
            Assert.Equal(15, result);
        }

        [Fact]
        public void Add_NumbersWithNewLines_ReturnsTheirSum()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var result = calculator.Add("1\n2,3");

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act
            var ex = Assert.Throws<Exception>(() =>
                calculator.Add("1,-2,3,-4")
            );

            // Assert
            Assert.Equal("negatives not allowed: -2,-4", ex.Message);
        }
    }
}