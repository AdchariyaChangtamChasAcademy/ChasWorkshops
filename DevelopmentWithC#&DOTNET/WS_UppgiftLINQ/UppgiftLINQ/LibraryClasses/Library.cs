using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UppgiftLINQ.ProductOrder;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UppgiftLINQ.LibraryClasses
{
    public class Library
    {
        public void RunLibrary()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "1984", Author = "George Orwell", Year = 1949, IsAvailable = true },
                new Book { Title = "Brave New World", Author = "Aldous Huxley", Year = 1932, IsAvailable = false },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937, IsAvailable = true },
                new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Year = 1953, IsAvailable = true }
            };

            List<Member> members = new List<Member>
            {
                new Member { Name = "Alice", BorrowedBooks = new List<string> { "Brave New World" } },
                new Member { Name = "Bob", BorrowedBooks = new List<string> { "1984", "The Hobbit" } }
            };

            //- []  Filtrera alla tillgängliga böcker(`Where`)
            Console.WriteLine("Available books:");
            var availableBooks = books.Where(b => b.IsAvailable);
            foreach (var book in availableBooks)
            {
                Console.WriteLine($"{book.Title}");
            }

            //- []  Sortera böcker efter år(`OrderBy`)
            Console.WriteLine("\nBooks ordered by year:");
            var booksByYear = books.OrderBy(b => b.Year);
            foreach (var book in booksByYear)
            {
                Console.WriteLine($"{book.Year}: {book.Title} by {book.Author}");
            }

            //- []  Projicera en lista med bara titlar(`Select`)
            Console.WriteLine("\nBooks titles:");
            var bookTitles = books.Select(b => b.Title);
            foreach (var book in bookTitles)
            {
                Console.WriteLine(book);
            }

            //- []  Hämta första bok som är tillgänglig(`FirstOrDefault`)
            Console.WriteLine("\nFirst available book in list:");
            var firstAvailable = books.FirstOrDefault(b => b.IsAvailable);
            Console.WriteLine(firstAvailable != null ? firstAvailable.Title : "Book not found.");

            //- []  Visa vilka medlemmar som har lånat en viss bok(`Where` + `Any`)
            Console.WriteLine("\nMember with borrowed books:");
            var memberWithBook = members
                .Where(m => m.BorrowedBooks.Count > 0)
                .Any(b => b.BorrowedBooks.Contains("1984"));
            Console.WriteLine(memberWithBook ? "1984 is borrowed." : "Book not found.");

            //- []  Gruppera böcker per författare(`GroupBy`)
            Console.WriteLine("\nBooks grouped by author:");
            var bookByAuthor = books
                .GroupBy(a => a.Author)
                .Select(b => new { Author = b.Key, Count = b.Count() });
            foreach (var book in bookByAuthor)
            {
                Console.WriteLine($"{book.Author}: {book.Count}");
            }
        }
    }
}
