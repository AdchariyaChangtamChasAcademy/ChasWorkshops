using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism
{
    internal class Tiger:Animal
    {
        public int Stripes { get; set; }
        public Tiger(string name, int stripes) : base(name)
        {
            Stripes = stripes;
        }

        public override void Call()
        {
            Console.WriteLine($"{Name} ryter!");
        }
    }
}
