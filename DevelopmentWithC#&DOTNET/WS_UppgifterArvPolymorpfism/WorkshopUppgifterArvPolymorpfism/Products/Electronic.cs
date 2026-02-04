using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Products
{
    public class Electronic:Product
    {
        public Electronic(string name, int price) : base(name, price) { }

        public override void GetProductInformation()
        {
            base.GetProductInformation();
            Console.WriteLine($" och den behöver el");
        }
    }
}
