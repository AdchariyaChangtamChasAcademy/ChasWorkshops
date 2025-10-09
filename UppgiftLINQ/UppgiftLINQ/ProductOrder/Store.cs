using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UppgiftLINQ.ProductOrder
{
    public class Store
    {
        public void RunStore()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 12000 },
                new Product { Name = "Mouse", Category = "Electronics", Price = 250 },
                new Product { Name = "Desk", Category = "Furniture", Price = 3000 },
                new Product { Name = "Chair", Category = "Furniture", Price = 1500 }
            };

            List<Order> orders = new List<Order>
            {
                new Order { CustomerName = "Anna", ProductNames = new List<string> { "Laptop", "Mouse" } },
                new Order { CustomerName = "Ben", ProductNames = new List<string> { "Desk", "Chair" } }
            };

            //- []  Filtrera produkter över 1000 kr(`Where`)
            Console.WriteLine("\nProducts with price over 1000:");
            var over1K = products.Where(p => p.Price > 1000);
            foreach (var product in over1K)
            {
                Console.WriteLine($"{product.Name}: {product.Price} SEK");
            }

            //- []  Sortera produkter per kategori(`OrderBy`)
            Console.WriteLine("\nProducts with price over 1000 SEK:");
            var orderedByCategory = products.OrderBy(p => p.Category);
            foreach (var product in orderedByCategory)
            {
                Console.WriteLine($"{product.Category}, {product.Name}:{product.Price} SEK");
            }

            //- []  Projicera produktnamn och pris(`Select`)
            Console.WriteLine("\nProducts name and price:");
            var productNameAndPrice = products.Select(p => new { p.Name, p.Price });
            foreach (var product in productNameAndPrice)
            {
                Console.WriteLine($"{product.Name}: {product.Price} SEK");
            }

            //- []  Beräkna total kostnad per order(`Join` + `Sum`)
            Console.WriteLine("\nCustomer name and order total price:");
            var orderTotalPrice = orders.Select
            (
                order => new
                {
                    order.CustomerName,                 //// OrderTotalPrice 1 = order customer name.
                    Total = order.ProductNames.Join(    //// OrderTotalPrice 2 = Total(joined).
                        products,                       // Join order.ProductNames list with the product list.
                        o => o,                         // OuterKeySelector = the product name from order.ProductNames
                        p => p.Name,                    // InnerKeySelector = the product name in the product list.
                        (o, p) => p.Price)              // ResultSelector = get price of matching product names.
                    .Sum()                              //// Sum of all the matched product prices to get total of order.
                }
            );

            foreach(var order in orderTotalPrice)
            {
                Console.WriteLine($"{order.CustomerName}: {order.Total} SEK");
            }

            //- []  Hämta alla kunder som köpt en viss produkt(`Where` + `Contains`)
            Console.WriteLine("\nCustomers that purchased Laptops:");
            var laptopCustomers = orders.Where(o => o.ProductNames.Contains("Laptop"));
            foreach (var order in laptopCustomers)
            {
                Console.WriteLine($"{order.CustomerName}");
            }

            //- []  Gruppera produkter per kategori och visa antal(`GroupBy` + `Count`)
            Console.WriteLine("\nCategory amounts:");
            var categoryAmount = products
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Amount = g.Count() });
            foreach (var ca in categoryAmount)
            {
                Console.WriteLine($"{ca.Category}: {ca.Amount}");
            }

        }
    }
}
