using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopRepetitionOOP
{
    public class Mission
    {
        public string Title { get; set; }
        public int Difficulty { get; set; }

        public Mission(string title, int difficulty)
        {
            Title = title;
            Difficulty = difficulty;
        }

        public void Describe()
        {
            Console.WriteLine($"Uppdrag {Title} med svårighetsgraden {Difficulty}");
        }
    }
}
