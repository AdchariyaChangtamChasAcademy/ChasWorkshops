using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGruppAventyr
{
    public class EnemyCharacter : Character
    {
        public int DamageToDeal { get; set; }
        public EnemyCharacter(string name, string type, int health, int damageToDeal) : base(name, type, health)
        {
            DamageToDeal = damageToDeal;
        }

        public override void Talk(Character character)
        {
            Console.WriteLine($"{Name} doesn't want to talk and starts a fight!");
            Fight(character);
        }

        public override void Fight(Character character)
        {
            Console.WriteLine($"{Name} deals {DamageToDeal} to your health!");
        }
    }
}
