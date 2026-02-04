namespace WorkshopCustomerData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Anna", Email = "anna@example.com", Age = 25 },
                new Customer { Name = "Ben", Email = "", Age = 17 },
                new Customer { Name = "Clara", Email = null, Age = 130 },
                new Customer { Name = "David", Email = "david@example.com", Age = 45 },
                new Customer { Name = "Alice", Email = " ", Age = 55 },
                new Customer { Name = "Bob", Email = "bob@example.com", Age = 12 }
            };

            Customer customer1 = new Customer { Name = "Charlie", Email = "charlie@example.com", Age = 145 };

            if (customer1.Validate())
                Console.WriteLine("Customer 1 good");
            else
                Console.WriteLine("Customer 1 bad");

            Console.WriteLine("Validerar kunddata...");
            var validCustomers = customers.Where(c => !string.IsNullOrWhiteSpace(c.Email) && c.Age >= 18 && c.Age <= 120);

            Console.WriteLine("\nGiltiga kunder:");
            foreach(var customer in validCustomers)
            { 
                Console.WriteLine($"   Name:{customer.Name} | Age:{customer.Age} | Email:{customer.Email}");
            }

            var invalidCustomersDueToEmail = customers.Where(c => string.IsNullOrWhiteSpace(c.Email));
            Console.WriteLine("\nOgiltiga kunder:");
            Console.WriteLine($"  Kunder med ogiltig emails [{invalidCustomersDueToEmail.Count()}]");
            foreach (var customerEmail in invalidCustomersDueToEmail)
            {
                Console.WriteLine($"    Name:{customerEmail.Name} | Age:{customerEmail.Age} | Email:{customerEmail.Email}");
            }

            var invalidCustomersDueToAge = customers.Where(c => !(c.Age >= 18 && c.Age <= 120));
            Console.WriteLine($"\n  Kunder med ogiltig ålder [{invalidCustomersDueToAge.Count()}]");
            foreach (var customerAge in invalidCustomersDueToAge)
            {
                Console.WriteLine($"    Name:{customerAge.Name} | Age:{customerAge.Age} | Email:{customerAge.Email}");
            }
        }
    }
}
