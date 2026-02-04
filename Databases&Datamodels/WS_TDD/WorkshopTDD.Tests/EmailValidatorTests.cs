using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTDD.Tests
{
    public class EMailValidatorTests
    {
        //"Ett system som fungerar för att kontrollera giltiga e-postadresser."
        //Funktion: IsValidEmail(string email)
        //Testa olika format, tomma strängar, specialtecken.

        [Theory]
        [InlineData("kalleanka@gmail.com")]
        [InlineData("123123123@hotmail.se")]
        [InlineData("@gmail.com")]
        [InlineData("@gmail.se")]
        [InlineData("email@mail.com")]
        public void Given_ValidEmail_When_Validated_Then_ShouldReturnTrue(string email)
        {
            //Given
            var validator = new EmailValidator();
            //string email = "kalleanka@gmail.com";

            //When
            bool result = validator.IsValid(email);

            //Then
            Assert.True(result);
        }
    }
}
