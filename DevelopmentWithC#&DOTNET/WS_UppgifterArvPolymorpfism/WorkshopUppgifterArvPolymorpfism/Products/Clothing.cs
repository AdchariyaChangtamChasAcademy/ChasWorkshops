using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Products
{
    public class Clothing:Product
    {
        public string Material { get; set; }
        public Clothing(string name, int price, string material) : base(name, price) 
        {
            Material = material;
        }

        public override void GetProductInformation()
        {
            base.GetProductInformation();
            Console.WriteLine($" och den är gjord av {Material}");
        }
    }
}
