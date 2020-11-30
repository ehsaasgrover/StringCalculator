using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorShould
    {
        private readonly Calculator _calculator;

        public CalculatorShould()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void ReturnZeroIfEmptyStringInput()
        {
            // Arrange
            const string input = "";
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("3", 3)]
        public void ReturnNumberAsIntIfSingularNumericStringInput(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("3,5", 8)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        public void ReturnSumAsIntIfMultipleCommaSeparatedNumericStringInputs(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("3\n5\n3,9", 20)]
        public void ReturnSumAsIntIfMultipleNewlineAndOrCommaSeparatedNumericStringInput(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//k\n1k2", 3)]
        public void ReturnSumAsIntIfCustomDelimiterSeparatedNumericStringInput(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("1000,1001,2", 2)]
        public void ReturnSumAsIntExceptValuesAboveThousandNumericStringInput(string input, int expected)
        {    
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}