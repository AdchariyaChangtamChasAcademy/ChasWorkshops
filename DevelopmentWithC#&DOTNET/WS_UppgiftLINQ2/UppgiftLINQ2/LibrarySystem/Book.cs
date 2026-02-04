using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UppgiftLINQ2.LibrarySystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class Member
    {
        public string Name { get; set; }
        public List<string> BorrowedBooks { get; set; }
    }

}
