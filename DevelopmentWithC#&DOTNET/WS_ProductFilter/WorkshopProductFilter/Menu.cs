using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopProductFilter
{
    public class Menu
    {
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public Stack<string> CategoryFilter { get; set; } = new Stack<String>();
        public decimal MaxPriceFilter { get; set; }

        public Menu(List<Product> list)
        {
            ProductsList = list ?? new List<Product>();
        }

        public void Start()
        {
            if (CategoryFilter.Count() > 0)
            {
                Console.Write("Current selected categories:");
                foreach (var category in CategoryFilter)
                {
                    Console.Write($"{category}");
                }
                Console.Write("\n");
            }


            Console.WriteLine("Selections:");
            Console.WriteLine("[1] Print products list");
            Console.WriteLine("[2] Category selection");
            Console.WriteLine("[3] Set max price");

            Console.Write("Choice:");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    PrintOutListOfProducts();
                    break;

                case "2":
                    Console.Clear();
                    CategoryChoice();
                    break;

                case "3":
                    Console.Clear();
                    MaxPriceChoice();
                    break;

                default:
                    Console.WriteLine("\nFaulty Selection, try again\n ");
                    CategoryChoice();
                    break;
            }
        }
        public void CategoryChoice()
        {
            Console.WriteLine("Select Category to show:");
            Console.WriteLine("[1] Electronics");
            Console.WriteLine("[2] Furniture");

            Console.Write("Choice:");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CategoryFilter.Push("Electronics");
                    break;

                case "2":
                    CategoryFilter.Push("Furniture");
                    break;

                default:
                    Console.WriteLine("\nFaulty Selection, try again\n ");
                    CategoryChoice();
                    break;
            }
            Console.Clear();
            Start();
        }

        public void MaxPriceChoice()
        {
            Console.WriteLine("Set max price of products to show:");
            Console.Write("Price:");
            string input = Console.ReadLine();
            decimal.TryParse(input, out decimal maxPrice);
            MaxPriceFilter = maxPrice;
            Start();
        }

        public void PrintOutListOfProducts()
        {
            //filteredList = ProductsList
            //    .Where(p => p.IsValid())
            //    .Where(p => p.Price <= MaxPriceFilter)
            //    .Where(p => CategoryFilter.Any(c => p.Category.Equals(c, StringComparison.OrdinalIgnoreCase)))
            //    .ToList();
            var filteredList = ProductsList.Where(p => p.IsValid());

            if (CategoryFilter.Count() > 0)
            {
                filteredList = filteredList.Where(p => CategoryFilter.Any(c => p.Category.Equals(c, StringComparison.OrdinalIgnoreCase))).ToList();
            }

            if(MaxPriceFilter > 0)
            {
                filteredList = filteredList.Where(p => p.Price <= MaxPriceFilter).ToList();
            }

            foreach (var product in filteredList)
            {
                Console.WriteLine($"    Name: {product.Name}|Category: {product.Category}|Price: {product.Price}");
            }

            Start();
        }
    }
}
