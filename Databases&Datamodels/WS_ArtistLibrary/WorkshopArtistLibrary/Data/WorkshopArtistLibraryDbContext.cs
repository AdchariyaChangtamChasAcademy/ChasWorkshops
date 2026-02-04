using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopArtistLibrary.Models;

namespace WorkshopArtistLibrary.Data
{
    public class WorkshopArtistLibraryDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=MusicStoreDB;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unika index
            modelBuilder.Entity<Artist>()
                .HasIndex(a => a.ArtistName)
                .IsUnique();

            modelBuilder.Entity<Genre>()
                .HasIndex(g => g.GenreName)
                .IsUnique();

            // Seed-data för Genre
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Rock" },
                new Genre { GenreId = 2, GenreName = "Pop" },
                new Genre { GenreId = 3, GenreName = "Jazz" },
                new Genre { GenreId = 4, GenreName = "Hip Hop" },
                new Genre { GenreId = 5, GenreName = "Classical" },
                new Genre { GenreId = 6, GenreName = "Metal" },
                new Genre { GenreId = 7, GenreName = "Country" },
                new Genre { GenreId = 8, GenreName = "Electronic" },
                new Genre { GenreId = 9, GenreName = "Reggae" },
                new Genre { GenreId = 10, GenreName = "Blues" }
            );

            // Seed-data för Artist
            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, ArtistName = "The Beatles" },
                new Artist { ArtistId = 2, ArtistName = "Beyoncé" },
                new Artist { ArtistId = 3, ArtistName = "Miles Davis" },
                new Artist { ArtistId = 4, ArtistName = "Eminem" },
                new Artist { ArtistId = 5, ArtistName = "Mozart" },
                new Artist { ArtistId = 6, ArtistName = "Metallica" },
                new Artist { ArtistId = 7, ArtistName = "Johnny Cash" },
                new Artist { ArtistId = 8, ArtistName = "Avicii" },
                new Artist { ArtistId = 9, ArtistName = "Bob Marley" },
                new Artist { ArtistId = 10, ArtistName = "BB King" }
            );

            // Seed-data för Album
            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, Title = "Abbey Road", FkArtistId = 1, FkGenreId = 1 },
                new Album { AlbumId = 2, Title = "Lemonade", FkArtistId = 2, FkGenreId = 2 },
                new Album { AlbumId = 3, Title = "Kind of Blue", FkArtistId = 3, FkGenreId = 3 },
                new Album { AlbumId = 4, Title = "The Marshall Mathers LP", FkArtistId = 4, FkGenreId = 4 },
                new Album { AlbumId = 5, Title = "Requiem", FkArtistId = 5, FkGenreId = 5 },
                new Album { AlbumId = 6, Title = "Master of Puppets", FkArtistId = 6, FkGenreId = 6 },
                new Album { AlbumId = 7, Title = "Ring of Fire", FkArtistId = 7, FkGenreId = 7 },
                new Album { AlbumId = 8, Title = "True", FkArtistId = 8, FkGenreId = 8 },
                new Album { AlbumId = 9, Title = "Exodus", FkArtistId = 9, FkGenreId = 9 },
                new Album { AlbumId = 10, Title = "Live at the Regal", FkArtistId = 10, FkGenreId = 10 }
            );
        }
    }
}
