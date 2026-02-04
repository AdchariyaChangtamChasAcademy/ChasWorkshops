using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopGenericCollections.Models;

namespace WorkshopGenericCollections.Repositories
{
    class ProductRepository
    {
        public List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Laptop Pro 14", Category = "Computers", Price = 18990 },
        new Product { Id = 2, Name = "Laptop Air 13", Category = "Computers", Price = 12990 },
        new Product { Id = 3, Name = "Mechanical Keyboard", Category = "Accessories", Price = 1290 },
        new Product { Id = 4, Name = "USB‑C Hub", Category = "Accessories", Price = 590 },
        new Product { Id = 5, Name = "Noise‑Canceling Headphones", Category = "Audio", Price = 2490 },
    };

        public List<Customer> Customers { get; } = new()
    {
        new Customer { Id = 1, Name = "Alex Andersson", Email = "alex@example.com" },
        new Customer { Id = 2, Name = "Sam Svensson", Email = "sam@example.com" },
    };

        private int _nextOrderId = 1;
        public Order CreateOrder(int customerId, int productId)
            => new() { Id = _nextOrderId++, CustomerId = customerId, ProductId = productId };
    }
}
