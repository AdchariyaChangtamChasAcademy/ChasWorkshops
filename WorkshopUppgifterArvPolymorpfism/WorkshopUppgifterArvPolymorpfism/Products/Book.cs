using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Products
{
    internal class Book:Product
    {
        public string Author { get; set; }
        public int Pages { get; set; }
        public Book(string name, int price, string author) : base(name, price) 
        {
            Author = author;
        }

        public override void GetProductInformation()
        {
            base.GetProductInformation();
            Console.WriteLine($" på {Pages} sidor och den är skriven av {Author} ");
        }
    }
}
