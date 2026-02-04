using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WorkshopLoggingDemo.Repositories;
using WorkshopLoggingDemo.Validators;
using WorkshopLoggingDemo.Models;
using WorkshopLoggingDemo.Repositories;

namespace WorkshopLoggingDemo.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo; // Vara och hämta kunder
        private readonly CustomerValidator _validator; // Validera data
        private readonly ILogger _logger; // Logga och hantera fel

        public CustomerService(ICustomerRepository repo, CustomerValidator validator, ILogger<CustomerService> logger)
        {
            _repo = repo;
            _validator = validator;
            _logger = logger;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                _validator.Validate(customer);
                _repo.Save(customer);
                _logger.LogInformation("Kund sparad: {Name}", customer.Name);
            }
            catch(InvalidCustomerException ex)
            {
                _logger.LogWarning(ex, "Valideringsfel för kund: {Email}", customer.Email);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Okänt fel vid sparande av kund.");
            }
        }
        public IEnumerable<Customer> FilterByDomain(string domain)
        {
            return _repo.GetAll().Where(c => c.Email.EndsWith(domain));
        }
    }
}
