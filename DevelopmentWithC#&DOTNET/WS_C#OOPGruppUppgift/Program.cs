namespace WorkshopC_OOPGruppUppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //## Uppgift i team 1
            /*


            // The author of Ice Hunt is James Rollins
            // 509 pages
            // Ice Hunt is a 2003 action-adventure thriller by James Rollins about an abandoned, secret Soviet research station, Grendel, hidden beneath an Arctic ice island. An American research vessel discovers the station, uncovering both biological horrors and a mystery about experiments that blurred the line between life and death. A covert international conflict erupts as U.S. and Russian forces vie for control, while an Alaskan park ranger, Matthew Pike, becomes entangled in the struggle, hunted by both the military and a newly discovered, ancient creature that survived within the ice station's depths.

            //Bok myBook = new Bok();
            //myBook.Title = "Ice Hunt";
            //myBook.Author = "James Rollins";
            //myBook.Pages = -509;

            //Console.WriteLine($"Boken {myBook.Title} skriven av {myBook.Author} är {myBook.Pages} sidor lång.");
            //myBook.printSummary();
            */

            //Skapa en klass Person med egenskaperna FirstName, LastName, och BirthYear.
            //Lägg till en metod GetAge() som beräknar ålder baserat på nuvarande år.

            //Utmaning:
            //Lägg till en konstruktor som automatiskt sätter alla värden vid instansiering.

            //Diskussionsfråga:
            //Vad är skillnaden mellan fält och properties ?

            Person myPerson = new Person("Kalle", "Anka", 1934);

            myPerson.printSummary();

            myPerson.FirstName = "Musse";
            myPerson.LastName = "Pigg";
            myPerson.BirthYear = 1928;

            myPerson.printSummary();
        }
    }
}
