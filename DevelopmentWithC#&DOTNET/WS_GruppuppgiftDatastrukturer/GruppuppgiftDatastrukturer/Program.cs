using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace GruppuppgiftDatastrukturer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             ### **1. Bokningssystem**
            */

            BookingSystem myBooking = new BookingSystem();
            myBooking.bookTime(DateTime.Today, myBooking.bookings.Count().ToString(), "Alice");
            myBooking.bookTime(new DateTime(2025,9,30), myBooking.bookings.Count().ToString(), "Bob");
            myBooking.bookTime(DateTime.Today, myBooking.bookings.Count().ToString(), "Charlie");

            /*
            ### **2. Elevregister**

            - [ ]  `List<string>` med elevnamn.
            - [ ]  `Dictionary<string, List<int>>` för att koppla varje elev till en lista med betyg.
            - [ ]  Beräkna medelbetyg för varje elev.
            - [ ]  Skriv ut alla elever med deras betyg.
            */

            List<string> studentNames = new List<string>
            {
                "Alice",
                "Bob",
                "Charlie"
            };

            Dictionary<string, List<int>> studentNameGrade = new Dictionary<string, List<int>>
            {
                { "Alice", new List<int>{ 1,2,3,4} },
                { "Bob", new List<int>{ 9,4,5,1} },
                { "Charlie", new List<int>{ 8,2,5,9} }
            };

            foreach (var student in studentNameGrade)
            {
                foreach (var name in studentNames)
                {
                    if (name == student.Key)
                    {
                        double medianGrade = student.Value.Average();
                        Console.WriteLine($"{name} medelbetyg är {medianGrade}");
                    }
                }
            }

            /*
            ### **3. Inloggningssystem**

            - [ ]  `Dictionary<string, string>` med användarnamn och lösenord.
            - [ ]  Fråga användaren om inloggning via `Console.ReadLine()`.
            - [ ]  Kontrollera om användarnamn finns (`ContainsKey`) och om lösenordet matchar.
            */

            Dictionary<string, string> namePasswords = new Dictionary<string, string>
            {
                { "Alice", "1"},
                { "Bob", "2"},
                { "Charlie", "3"}
            };

            Console.Write("Skriv in användarnamn: ");
            string inputName = Console.ReadLine();

            if (namePasswords.ContainsKey(inputName))
            {
                Console.Write("Skriv in lösenord: ");
                string inputPassword = Console.ReadLine();

                namePasswords.TryGetValue(inputName, out string password);

                if (inputPassword == password)
                {
                    Console.WriteLine("Du är inloggad!");
                }
                else
                {
                    Console.WriteLine("Fel lösenord!");
                }
            }
            else
            {
                Console.WriteLine("Användarnamnet finns inte!");
            }

            /*
            ### **4. Produkthanteringssystem**

            - [ ]  Skapa en `List<string>` med produktnamn.
            - [ ]  Lägg till, ta bort och sortera produkter.
            - [ ]  Skapa en `Dictionary<string, double>` med produktnamn och pris.
            - [ ]  Skriv ut alla produkter med pris.
            - [ ]  Skapa en `HashSet<string>` med registrerade e-postadresser.
            - [ ]  Testa att lägga till dubbletter.
            */

            List<string> productNames = new List<string>();

            productNames.Add("Mjölk");
            productNames.Add("Banan");
            productNames.Add("Smör");

            productNames.Remove("Banan");

            productNames.Sort();

            Console.WriteLine($"\n");

            Dictionary<string, double> productPrice = new Dictionary<string, double>();

            productPrice.Add("Mjölk", 27.00);
            productPrice.Add("Banan", 35.00);
            productPrice.Add("Smör", 60.00);

            foreach(var product in productPrice)
            {
                Console.WriteLine($"{product.Key} kostar {product.Value}kr");
            }

            Console.WriteLine($"\n");

            HashSet<string> emails = new HashSet<string>();

            emails.Add("Alice@email.com");
            emails.Add("Bob@email.com");
            emails.Add("Charlie@email.com");

            emails.Add("Alice@email.com");


            foreach (var email in emails)
            {
                Console.WriteLine($"{email}");
            }
        }

        
    }
}
