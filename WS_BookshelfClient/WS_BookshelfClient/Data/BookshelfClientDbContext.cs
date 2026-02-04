using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_BookshelfClient.Models;

namespace WS_BookshelfClient.Data
{
    public class BookshelfClientDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookshelfDb;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
