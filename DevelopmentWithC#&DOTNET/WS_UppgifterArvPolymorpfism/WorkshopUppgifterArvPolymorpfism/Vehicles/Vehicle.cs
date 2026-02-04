using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism.Vehicles
{
    public class Vehicle
    {
        public int Speed { get; set; }
        public string FuelType { get; set; }

        public Vehicle(int speed, string fuelType)
        {
            Speed = speed;
            FuelType = fuelType;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"Speed: {Speed}, Fuel type: {FuelType}");
        }
    }
}
