namespace WorkshopProductFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 12000m },
                new Product { Name = "Desk", Category = "Furniture", Price = 3000m },
                new Product { Name = "Mouse", Category = null, Price = 250m },
                new Product { Name = "Chair", Category = "Furniture", Price = -1500m },
                new Product { Name = "Lamp", Category = "Furniture", Price = 500m }
            };

            Menu myMenu = new Menu(products);
            myMenu.Start();

            Console.ReadLine();
        }
    }
}
