using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism
{
    internal class Wolf:Animal
    {
        public int PackMembers { get; set; }
        public Wolf(string name, int packmembers) : base(name) 
        {
            PackMembers = packmembers;
        }

        public override void Call()
        {
            Console.WriteLine($"{Name} ylar!");
        }
    }
}
