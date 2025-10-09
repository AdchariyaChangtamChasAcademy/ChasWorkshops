using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGruppAventyr
{
    public class PlayerCharacter : Character
    {
        List<string> Inventory = new List<string>();
        public PlayerCharacter(string name, string type, int health) : base(name, type, health)
        {
            
        }

        public virtual void AddItem(string itemToAdd)
        {
            Inventory.Add(itemToAdd);
        }

        public virtual void CheckInventory()
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i}. {Inventory[i]}");
            }
        }
    }
}
