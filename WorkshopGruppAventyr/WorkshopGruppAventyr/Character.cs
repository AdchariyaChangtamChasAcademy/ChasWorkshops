using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGruppAventyr
{
    public class Character
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }

        public Character(string name, string type, int health)
        {
            Name = name;
            Type = type;
            Health = health;
        }

        public virtual void Talk(Character character) { }
        public virtual void Fight(Character character) { }
        public virtual void Run(Character character) { }

        public virtual void AlterHealth(int alterAmount) 
        {
            Health += alterAmount;
        }
    }
}
