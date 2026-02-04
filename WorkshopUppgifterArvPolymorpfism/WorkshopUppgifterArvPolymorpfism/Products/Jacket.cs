using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Products
{
    public class Jacket:Clothing
    {
        public Jacket(string name, int price, string material) : base(name, price, material) { }
    }
}
