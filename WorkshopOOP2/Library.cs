using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopOOP2
{
    public class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void PrintBooks()
        {
            foreach(var book in Books)
            {
                Console.WriteLine($"- {book.Title} skriven av {book.Author}");
            }
        }
    }
}
