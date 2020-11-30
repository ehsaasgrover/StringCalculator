using System;
using Xunit;

namespace StringCalculator.Tests
{
    public class AddShould
    {
        Calculator calc = new Calculator();
        
        
        [Theory]
        [InlineData("",0)]
        [InlineData("1",1)]
        [InlineData("3",3)]
        [InlineData("1,2",3)]
        [InlineData("3,5",8)]
        [InlineData("1,2,3",6)]
        [InlineData("1,2,3,4",10)]
        [InlineData("3\n5\n3,9",20)]
        [InlineData("//;\n1;2",3)]
        [InlineData("//k\n1k2",3)]
        public void ReturnSumOfInput(string input, int number)
        {    
            // Arrange
            // Act
            var actual = calc.Add(input);
            // Assert
            Assert.Equal(number,actual);
        }

        

    }
}