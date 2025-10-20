using WorkshopLoggingDemo.Models;

namespace WorkshopLoggingDemo.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        IEnumerable<Customer> GetAll();
    }
}
