using System.Text.RegularExpressions;
using WS_BookshelfClient.Data;
using WS_BookshelfClient.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WS_BookshelfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var DB = new BookshelfClientDbContext();

            var allAuthors = DB.Authors.ToList();

            Console.WriteLine("All authors:");
            foreach (var a in allAuthors)
            {
                Console.Write($"- {a.FirstName} {a.LastName}");
            }

            //Frågesyntax
            var thrillerBooksQuery = from b in DB.Books
                                     where b.Genre == "Thriller"
                                     select b;
            Console.WriteLine("Query:");
            foreach (var book in thrillerBooksQuery)
            {
                Console.WriteLine(book.Title);
            }

            // Metodsyntax
            var thrillerBooksMethod = DB.Books
                .Where(b => b.Genre == "Thriller")
                .ToList();
            Console.WriteLine("Method:");
            foreach (var book in thrillerBooksMethod)
            {
                Console.WriteLine(book.Title);
            }

            // FirstOrDefault(), Most effective if searching for a specific item
            // First(), crashes if item not found
            // Single(), requires that exacly one item that matches else crashes
            var oneBookToFind = DB.Books
                .FirstOrDefault(b => b.Title == "Harry Potter");
            if (oneBookToFind != null)
            {
                Console.WriteLine(oneBookToFind.Title);
            }


            //// Standard operations

            // OrderBy()
            var sortedBooks = DB.Books
                .OrderBy(b => b.Title)
                .ToList();
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(book.Title);
            }

            // Any(), if exist returns TRUE else if doesn't exist returns FALSE
            var hasBook = DB.Books.Any(b => b.Genre == "Romance");

            // All(), returns all item that exists, returns false if no item found
            var allHaveAuthors = DB.Books.All(b => b.AuthorID != 0);

            // First(), returns first book in database, crashes if item not found
            var firstBook = DB.Books.First();

            //// INNER JOIN
            // (SELECT b.Title, a.FirstName, a.LastName FROM Books b INNER JOIN Authors a ON b.AuthorID = a.AuthorID;)
            var bookAuthors = DB.Books
                .Join(DB.Authors,
                    book => book.AuthorID,
                    author => author.AuthorID,
                    (book, author) => new { book.Title, author.FirstName, author.LastName })
                .ToList();
            foreach (var b in bookAuthors)
            {
                Console.WriteLine($"{b.Title} - {b.FirstName} {b.LastName}");
            }

            // GROUP JOIN 
            // (LEFT JOIN) (SELECT a.AuthorID, COUNT(b.AuthorID) FROM Authors a LEFT JOIN Books b ON a.AuthorID = b.AuthorID GROUP BY a.AuthorID;)
            var booksCount = DB.Authors
                .GroupJoin(DB.Books,
                    a => a.AuthorID,
                    b => b.AuthorID,
                    (a, books) => new { a.AuthorID, Count = books.Count() })
                .ToList();
            foreach (var b in booksCount)
            {
                Console.WriteLine($"{b.AuthorID}: {b.Count}");
            }
        }
    }
}
