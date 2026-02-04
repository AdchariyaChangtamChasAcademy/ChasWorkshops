using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopTeamAnimalDuel
{
    class AnimalFactory
    {
        public static Animal Create(string input)
        {

            input = input.ToLower();

            if (input == "elephant")
            {
                return new Elephant();
            }
            else if (input == "tiger")
            {
                return new Tiger();
            }
            else if (input == "fox")
            {
                return new Fox();
            }
            else
            {
                return null;
            }
        }
    }
}
