using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppuppgiftDatastrukturer
{
    internal class BookingSystem
    {
        /*
            ### **1. Bokningssystem**

           - [ ]  `List<string>` för att lagra bokningar i ordning.
           - [ ]  `Dictionary<string, string>` för att koppla boknings-ID till kundnamn.
           - [ ]  `HashSet<DateTime>` för att hålla koll på unika bokningsdatum.
           - [ ]  Kontrollera om ett datum redan är bokat innan ny bokning läggs till.

        */

        public List<string> bookings { get; set; }
        public Dictionary<string, string> bookingIdToName { get; set; }
        public HashSet<DateTime> bookingTime { get; set; }

        public BookingSystem()
        {
            bookings = new List<string>();
            bookingIdToName = new Dictionary<string, string>();
            bookingTime = new HashSet<DateTime>();
        }

    public void bookTime(DateTime date, string id, string name)
        {
            if (bookingTime.Contains(date))
            {
                Console.WriteLine($"Datumet {date.ToShortDateString()} är redan bokat.");
                return;
            }
            else
            {
                bookingTime.Add(date);
                bookings.Add(id);
                bookingIdToName[id] = name;
                Console.WriteLine($"Bokning skapad: {id} för {name} den {date.ToShortDateString()}");
            }
        }
    }
}
