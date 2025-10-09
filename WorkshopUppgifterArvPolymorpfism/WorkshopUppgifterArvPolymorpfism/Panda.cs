using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism
{
    public class Panda:Animal
    {
        bool IsRedPanda;
        public Panda(string name, bool isRedPanda) : base(name) 
        {
            IsRedPanda = isRedPanda;
        }

        public override void Call()
        {
            Console.WriteLine($"{Name} morrar!");
        }
    }
}
