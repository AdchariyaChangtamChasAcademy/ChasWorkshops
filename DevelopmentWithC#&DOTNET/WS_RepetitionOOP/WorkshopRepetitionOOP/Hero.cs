using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopRepetitionOOP
{
    public class Hero
    {
        public string Name { get; set; }
        public string Power { get; set; }

        public Hero(string name, string power)
        {
            Name = name;
            Power = power;
        }

        public virtual void PerformMission(Mission mission)
        {
            Console.WriteLine($"{Name} använder {Power} för att utföra uppdraget: {mission.Title}");
        }

        public void Rest()
        {
            Console.WriteLine($"{Name} vilar efter uppdraget.");
        }
    }
}
