using WS_EcommerceClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Runtime.InteropServices;

namespace WS_EcommerceClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using var context = new EcommerceDbContext();
            //var stockholmCustomers = context.Customers.Where(c => c.City == "Stockholm").ToList();
            //Console.WriteLine($"Hittade {stockholmCustomers.Count} kunder");

            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            var connectionString = builder.GetConnectionString("ECommerceDBB");

            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var options = optionsBuilder.Options;

            using var context = new EcommerceDbContext(options);

            var products = context.Products.Where(p => p.Price < 500).ToList();
            Console.WriteLine($"Antal billiga produkter: {products.Count}");
        }
    }
}
