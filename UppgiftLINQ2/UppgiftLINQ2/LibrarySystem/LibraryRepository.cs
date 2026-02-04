using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftLINQ2.LibrarySystem
{
    public static class LibraryRepository
    {
        public static List<Book> GetBooks() => new List<Book>
        {
            new Book { Title = "1984", Author = "George Orwell", Year = 1949, IsAvailable = true },
            new Book { Title = "Brave New World", Author = "Aldous Huxley", Year = 1932, IsAvailable = false },
            new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937, IsAvailable = true },
            new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Year = 1953, IsAvailable = true }
        };

        public static List<Member> GetMembers() => new List<Member>
        {
            new Member { Name = "Alice", BorrowedBooks = new List<string> { "Brave New World" } },
            new Member { Name = "Bob", BorrowedBooks = new List<string> { "1984", "The Hobbit" } }
        };
    }
}
