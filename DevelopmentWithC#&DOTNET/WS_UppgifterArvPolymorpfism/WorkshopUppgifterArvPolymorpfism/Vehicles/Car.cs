using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Vehicles
{
    public class Car : Vehicle
    {
        public Car(int speed, string fuelType) : base(speed, fuelType) { }

        public string FuelType { get; set; }
        public override void Describe()
        {
            Console.WriteLine($"Det här är en BIL som kör i {Speed} och går i {FuelType}");
        }
    }
}
