using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UppgiftLINQ2.LibrarySystem
{
    public static class LibraryService
    {
        //Skriv om varje metod i `LibraryService.cs` med hjälp av LINQ och lambdauttryck.Du får använda `Where`, `Select`, `OrderBy`, `FirstOrDefault`, `Contains`, `GroupBy` m.fl.

        //**TIPS!**

        //- Testa varje metod direkt i `Main()` – du ser resultatet i konsolen.
        //- Använd `var` för att låta kompilatorn lista ut typen.
        //- Skriv ut resultatet med `foreach` för att se vad din LINQ-fråga returnerar.
        //- Om du är osäker på syntaxen – börja med en vanlig loop och jämför.

        //- [ ]  `GetAvailableBooks(List<Book> books)`
        //    - Filtrera alla böcker där `IsAvailable == true`
        //    - Använd `Where`
        public static void GetAvailableBooks(List<Book> books)
        {
            var availableBooks = books.Where(b => b.IsAvailable);

            foreach(var book in availableBooks)
            {
                Console.WriteLine($"{book.Title} är ledig");
            }
        }

        //- [ ]  `GetBooksSortedByYear(List<Book> books)`
        //    - Sortera böcker stigande efter `Year`
        //    - Använd `OrderBy`
        public static void GetBooksSortedByYear(List<Book> books)
        {
            var booksSortedByYear = books.OrderBy(b => b.Year);
            foreach(var book in booksSortedByYear)
            {
                Console.WriteLine($"{book.Year}: {book.Title} av {book.Author}");
            }
        }

        //- [ ]  `GetBookTitles(List<Book> books)`
        //    - Returnera en lista med bara titlar
        //    - Använd `Select`
        public static void GetBookTitles(List<Book> books)
        {
            var titlesOnly = books.Select(b => b.Title);
            foreach(var book in titlesOnly)
            {
                Console.WriteLine($"{book}");
            }
        }

        //- [ ]  `GetFirstAvailableBook(List<Book> books)`
        //    - Returnera första bok som är tillgänglig
        //    - Använd `FirstOrDefault`
        public static void GetFirstAvailabeBook(List<Book> books)
        {
            var firstAvailable = books.FirstOrDefault(b => b.IsAvailable);
            Console.WriteLine(firstAvailable != null ? $"Första lediga bok är {firstAvailable.Title}" : "Inga böcker lediga");
        }

        //- [ ]  `GetMembersWhoBorrowed(string title, List<Member> members)`
        //    - Returnera alla medlemmar som har lånat en viss bok
        //    - Använd `Where` + `Contains`
        public static void GetMembersWhoBorrowed(string title, List<Member> members)
        {
            var membersWithBorrowedTitle = members.Where(m => m.BorrowedBooks.Contains(title));
            foreach(var member in membersWithBorrowedTitle)
            {
                Console.WriteLine($"{member.Name} har lånatboken {title}");
            }
        }

        //- [ ]  `GroupBooksByAuthor(List<Book> books)`
        //    - Gruppera böcker per författare
        //    - Använd `GroupBy`
        public static void GroupBooksByAuthor(List<Book> books)
        {
            var groupedAuthor = books.GroupBy(b => b.Author);

            foreach (var group in groupedAuthor)
            {
                Console.WriteLine($"Author: {group.Key}");
                foreach (var authorsBooks in group)
                {
                    Console.WriteLine($"  Bok: {authorsBooks.Title}");
                }
            }
        }
    }
}
