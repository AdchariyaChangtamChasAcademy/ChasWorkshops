using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopRepetitionOOP
{
    public class SuperHero : Hero
    {
        public int Level { get; set; }
        
        public SuperHero(string name, string power, int level):base(name, power)
        {
            Level = level;
        }

        public override void PerformMission(Mission mission)
        {
            //base.PerformMission(mission);
            Console.WriteLine($"{Name} är på nivå {Level} och använder {Power} för att ta sig an uppdraget: {mission.Title}");

            if(Level >= mission.Difficulty)
            {
                Console.WriteLine("Uppdraget lyckades!");
            }
            else
            {
                Console.WriteLine("Uppdraget misslyckades, det var för svårt!");
            }
        }
    }
}
