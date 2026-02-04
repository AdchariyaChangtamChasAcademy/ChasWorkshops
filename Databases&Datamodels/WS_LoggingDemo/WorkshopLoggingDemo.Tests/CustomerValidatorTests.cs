using Xunit;
using WorkshopLoggingDemo;
using WorkshopLoggingDemo.Validators;
using WorkshopLoggingDemo.Models;

namespace WorkshopLoggingDemo.Tests
{
    public class CustomerValidatorTests
    {
        [Fact]
        public void ThrowsException_WhenEmailIsInvalid()
        {
            var validator = new CustomerValidator();
            var customer = new Customer { Name = "Malin", Email = "malin[at]example" };

            Assert.Throws<InvalidCustomerException>(() => validator.Validate(customer));
        }
    }
}