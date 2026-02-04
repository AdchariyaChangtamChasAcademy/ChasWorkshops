using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Vehicles
{
    public class Bicycle:Vehicle
    {
        public Bicycle(int speed, string fuelType) : base(speed, fuelType) { }

        public override void Describe()
        {
            Console.WriteLine($"Det här är en CYKEL som kör i {Speed} och går i {FuelType}");
        }
    }
}
