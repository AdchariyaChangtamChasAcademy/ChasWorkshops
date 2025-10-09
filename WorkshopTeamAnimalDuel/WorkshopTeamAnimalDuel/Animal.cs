using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTeamAnimalDuel
{
    public class Animal
    {

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
        public int Intelligence { get; set; }

        public int Wins { get; set; }

        public Animal(string name, int strength, int speed, int intelligence)
        {
            Name = name;
            Strength = strength;
            Speed = speed;
            Intelligence = intelligence;

            ApplyRandomEvolution();
        }

        public virtual void Duel(Animal animalToDuel)
        {
            KeyValuePair<string,int> myBest = GetDominantAttribute(this);
            KeyValuePair<string,int> otherBest = GetDominantAttribute(animalToDuel);

            Console.WriteLine($"\n{Name} [STR:{this.Strength}|SPD:{this.Speed}|INT:{this.Intelligence}] VS {animalToDuel.Name} [STR:{animalToDuel.Strength}|SPD:{animalToDuel.Speed}|INT:{animalToDuel.Intelligence}]");
            if (myBest.Value > otherBest.Value)
            {
                Console.WriteLine($"{Name}:{myBest.Key} wins against {animalToDuel.Name}:{otherBest.Key}");
                this.Wins += 1;
            }
            else if(myBest.Value < otherBest.Value)
            {
                Console.WriteLine($"{animalToDuel.Name}:{otherBest.Key} wins against {Name}:{myBest.Key}");
                animalToDuel.Wins += 1;
            }
            else if(myBest.Value == otherBest.Value)
            {
                Console.WriteLine($"It's a stand still between {Name}:{myBest.Key} and {animalToDuel.Name}:{otherBest.Key}");
            }
            else
            {
                Console.WriteLine("Duel error");
            }
        }

        public KeyValuePair<string, int> GetDominantAttribute(Animal animal)
        {
            Dictionary<string, int> allAttributes = new Dictionary<string, int>
            {
                { "STR", animal.Strength },
                { "SPD", animal.Speed },
                { "INT", animal.Intelligence }
            };

            KeyValuePair<string, int> dominantAttribute = allAttributes.OrderByDescending(a => a.Value).First();

            return dominantAttribute;
        }

        public void ApplyRandomEvolution()
        {
            int change = (int)(Speed * 0.1);
            Speed += new Random().Next(-change, change+1);

            change = (int)(Strength * 0.1);
            Strength += new Random().Next(-change, change+1);

            change = (int)(Intelligence * 0.1);
            Intelligence += new Random().Next(-change, change+1);
        }
    }
}
