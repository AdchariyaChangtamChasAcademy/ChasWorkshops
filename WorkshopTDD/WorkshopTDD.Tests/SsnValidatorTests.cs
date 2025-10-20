using System.ComponentModel.DataAnnotations;

namespace WorkshopTDD.Tests
{
    public class SsnValidatorTests
    {
        [Theory]
        [InlineData("0123456789")]
        [InlineData("9128374129")]
        [InlineData("9876543210")]
        public void Given_ValidSsn_When_Validated_Then_ShouldReturnTrue(string input)
        {
            //Given / Arrange
            var validator = new SsnValidator();
            //string input = "0123456789";

            //When / Act
            bool result = validator.IsValid(input);

            //Then / Assert
            Assert.True(result);
        }

        [Fact]
        public void Given_TooShortInput_When_Validated_Then_ShouldReturnFalse()
        {
            var validator = new SsnValidator();
            string input = "0123";
            bool result = validator.IsValid(input);
            Assert.False(result);
        }

        [Fact]
        public void Given_InputWithLetters_When_Validated_Then_ShouldReturnFalse()
        {
            var validator = new SsnValidator();
            string input = "abc";
            bool result = validator.IsValid(input);
            Assert.False(result);
        }
    }
}