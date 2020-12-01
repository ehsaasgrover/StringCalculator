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
        [InlineData("//[***]\n1***2***3", 6)]
        [InlineData("//[||]\n1||2||5", 8)]
        public void ReturnSumAsIntIfCustomDelimiterOfAnyLengthSeparatedNumericStringInput(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[***][#][%]\n1***2#3%4", 10)]
        [InlineData("//[*1*][%]\n1*1*2%3", 6)]
        public void ReturnSumAsIntIfMultipleCustomDelimitersOfAnyLengthSeparatedNumericStringInput(string input, int expected)
        {
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }
        
        
        [Theory]
        [InlineData("1000,1001,2", 2)]
        [InlineData("4900,1001,5", 5)]
        public void ReturnSumAsIntExceptValuesAboveThousandNumericStringInput(string input, int expected)
        {    
            // Arrange
            // Act
            var actual = _calculator.Add(input);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("-1,2,-3", "Negatives not allowed: -1, -3")]
        [InlineData("4,-11,-3,5", "Negatives not allowed: -11, -3")]
        public void ThrowExceptionIfNegativeNumericStringInput(string input, string expected)
        {
            // Arrange
            
            // Act
            // Assert
            var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));
            Assert.Equal(expected, exception.Message);
        }
        
        
    }
}