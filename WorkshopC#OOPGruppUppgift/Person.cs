using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopC_OOPGruppUppgift
{
    internal class Person
    {
        //Uppgift i team 3
        //Skapa en klass Person med egenskaperna FirstName, LastName, och BirthYear.
        //Lägg till en metod GetAge() som beräknar ålder baserat på nuvarande år.

        //Utmaning:
        //Lägg till en konstruktor som automatiskt sätter alla värden vid instansiering.

        //Diskussionsfråga:
        //Vad är skillnaden mellan fält och properties ?

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }

        public Person(string firstName, string lastName, int birthYear)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
        }

        public int GetAge()
        {
            int age = 0;
            // Berräkna år genom att substrahera nuvarande år med BirthYear
            age = (DateTime.Now.Year) - BirthYear;

            return age;
        }
        public void printSummary()
        {
            Console.WriteLine($"{FirstName} {LastName} är {GetAge()} år gammal.");
        }
    }
}
