using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGruppAventyr
{
    public class FriendlyCharacter : Character
    {
        public FriendlyCharacter(string name, string type, int health) : base(name, type, health)
        {
        }

        public override void Talk(Character character)
        {
            Console.WriteLine($"Hello Adventurer I shall grant you some help!");
        }

        public virtual void Help(Character character)
        {
            character.Health += 20;
        }
    }
}
