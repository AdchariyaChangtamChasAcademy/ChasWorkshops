using WorkshopLoggingDemo.Models;

namespace WorkshopLoggingDemo.Validators
{
    public class CustomerValidator
    {
        public void Validate(Customer customer)
        { 
            if (string.IsNullOrWhiteSpace(customer.Name)) 
                throw new InvalidCustomerException("Namn saknas."); 

            if (!customer.Email.Contains("@")) 
                throw new InvalidCustomerException("Ogiltig e-post."); 
        }
    }
}
