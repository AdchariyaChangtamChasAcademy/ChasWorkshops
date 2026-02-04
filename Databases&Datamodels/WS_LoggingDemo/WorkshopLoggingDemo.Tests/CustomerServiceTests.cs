using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopLoggingDemo.Models;
using WorkshopLoggingDemo.Repositories;
using WorkshopLoggingDemo.Services;
using WorkshopLoggingDemo.Validators;

namespace WorkshopLoggingDemo.Tests
{
    public class CustomerServiceTests
    {

        [Fact]
        public void LogsWarning_WhenValidationFails()
        {
            var repoMock = new Mock<ICustomerRepository>();
            var loggerMock = new Mock<ILogger<CustomerService>>();
            var validator = new CustomerValidator();
            var service = new CustomerService(repoMock.Object, validator, loggerMock.Object);

            var invalidCustomer = new Customer { Name = "", Email = "test@example.com" };
            service.AddCustomer(invalidCustomer);

            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Warning,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Valideringsfel")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}


