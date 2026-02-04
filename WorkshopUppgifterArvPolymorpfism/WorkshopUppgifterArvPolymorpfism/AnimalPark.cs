using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopUppgifterArvPolymorpfism
{
    public class AnimalPark
    {
        List<Animal> Animals = new List<Animal>();

        public void addAnimal(Animal animalToAdd)
        {
            Animals.Add(animalToAdd);
        }


        public void printAllAnimals()
        {
            foreach (var animal in Animals)
            {
                animal.Call();
            }
        }
    }
}
