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

            Console.WriteLine("Choose Category:");
            Console.WriteLine("[1] Electronics");
            Console.WriteLine("[2] Furniture");

            Console.Write("Choice:");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine("Electronics");
                    break;

                case "2":
                    Console.WriteLine("Furniture");
                    break;

                default:
                    Console.WriteLine("Faulty");
                    break;
            }
        }
    }
}
