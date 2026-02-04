using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopC_OOPGruppUppgift
{
    public class Bok
    {
        // Skapa en klass Book med egenskaperna
        // Title, Author, och Pages. Lägg till en metod PrintSummary()
        // som skriver ut en kort sammanfattning.

        //### Utmaning:
        // Lägg till en property som kontrollerar att antalet
        // sidor är större än 0.

        //### Diskussionsfråga:
        // Hur kan inkapsling hjälpa till att undvika fel i större program ?

        // Title, Author, och Pages.
        public string Title;
        public string Author;

        // Private field
        private int pages;

        //Property
        public int Pages 
        {
            get { return pages; }
            set 
            {
                if (value >= 0) 
                {
                    pages = value;
                }
            } 
        }

        // Print summary. Metod.
        public void printSummary()
        {
            Console.WriteLine("Ice Hunt is a 2003 action-adventure thriller by James Rollins about an abandoned, secret Soviet research station, Grendel, hidden beneath an Arctic ice island. An American research vessel discovers the station, uncovering both biological horrors and a mystery about experiments that blurred the line between life and death. A covert international conflict erupts as U.S. and Russian forces vie for control, while an Alaskan park ranger, Matthew Pike, becomes entangled in the struggle, hunted by both the military and a newly discovered, ancient creature that survived within the ice station's depths.");
        }
    }
}
