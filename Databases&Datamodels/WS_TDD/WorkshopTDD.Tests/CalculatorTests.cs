using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTDD.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, 5, 0)]
        [InlineData(100, 250, 350)]
        public void Given_TwoIntegers_When_Added_Then_ShouldReturnSum(int a, int b, int expected)
        {
            // Given
            var calculator = new Calculator();
            //int a = 3;
            //int b = 5;

            // When
            int result = calculator.Add(a, b);

            //Then
            Assert.Equal(expected, result);
        }
    }
}
