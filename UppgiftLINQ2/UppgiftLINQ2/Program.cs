using UppgiftLINQ2.LibrarySystem;

namespace UppgiftLINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = LibraryRepository.GetBooks();
            var members = LibraryRepository.GetMembers();

            Console.WriteLine("Tillgängliga böcker:");
            //ToDo skriv ut tillgängliga böcker
            LibrarySystem.LibraryService.GetAvailableBooks(books);

            Console.WriteLine("\nBöcker sorterade efter år:");
            //ToDo skriv ut böcker sorterade efter år
            LibrarySystem.LibraryService.GetBooksSortedByYear(books);

            Console.WriteLine("\nBoktitlar:");
            //ToDo skriv ut alla boktitlar
            LibrarySystem.LibraryService.GetBookTitles(books);

            Console.WriteLine("\nFörsta tillgängliga bok:");
            //ToDo skriv ut första tillgängliga bok
            LibrarySystem.LibraryService.GetFirstAvailabeBook(books);

            Console.WriteLine("\nMedlemmar som lånat 'The Hobbit':");
            //ToDo skriv ut alla medlemmar som lånat boken The Hobbit
            LibrarySystem.LibraryService.GetMembersWhoBorrowed("The Hobbit", members);

            Console.WriteLine("\nBöcker grupperade per författare:");
            //ToDo skriv ut böcker grupperade efter författare
            LibrarySystem.LibraryService.GroupBooksByAuthor(books);
        }
    }
}
