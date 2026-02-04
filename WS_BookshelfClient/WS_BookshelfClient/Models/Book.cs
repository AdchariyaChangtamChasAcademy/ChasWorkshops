using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_BookshelfClient.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
