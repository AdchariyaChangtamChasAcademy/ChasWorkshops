using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopC_OOP1
{
    public class Animal
    {
        //public string Name;
        //public string Species;
        //public int Age;


        //Incapsulation
        /*
        // OBS public = stor versal, private = liten versal
         
        private string name;
        private string species;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0) { age = value; }
            }
        }
        */

        //Constructor with method
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public Animal(string name, string species, int age)
        {
            Name = name;
            Species = species;
            Age = age;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Name} är ett {Species} och är {Age} år gammal.");
        }
    }
}
