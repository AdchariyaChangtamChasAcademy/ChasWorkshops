using WorkshopArtistLibrary.Data;

namespace WorkshopArtistLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new WorkshopArtistLibraryDbContext();

            var allArtists = db.Artists
            .OrderBy(a => a.ArtistId)
            .ToList();
            Console.WriteLine("Alla artister");
            foreach (var a in allArtists)
            {
                Console.WriteLine($"- {a.ArtistName}");
            }

            // Frågesyntax

            var rockAlbumsQuery = from a in db.Albums
                                  where a.Genre.GenreName == "Rock"
                                  select a;
            foreach (var album in rockAlbumsQuery)
            {
                Console.WriteLine(album.Title);
            }

            // Metodsyntax
            var rockAlbumsMethod = db.Albums
            .Where(a => a.Genre.GenreName == "Rock")
            .ToList();
            Console.WriteLine("\nRockalbum (metodsyntax)");
            foreach (var album in rockAlbumsMethod)
            {
                Console.WriteLine(album.Title);
            }

            //Frågesyntax
            var query = from a in db.Artists
                        where a.ArtistName == "Beyoncé"
                        select a;
            foreach (var artist in query)
            {
                Console.WriteLine($"ArtistId: {artist.ArtistId}, Namn: {artist.ArtistName}");
            }

            //Metodsyntax
            var query1 = db.Artists
            .Where(a => a.ArtistName == "Beyoncé")
            .Select(a => a);
            foreach (var artist in query1)
            {
                Console.WriteLine($"ArtistId: {artist.ArtistId}, Namn: {artist.ArtistName}");
            }

            //FirstOrDefault()
            var artist1 = db.Artists
            .FirstOrDefault(a => a.ArtistName == "Beyoncé");
            if (artist1 != null)
            {
                Console.WriteLine($"ArtistId: {artist1.ArtistId}, Namn: {artist1.ArtistName}");
            }

            //Single()
            var artist2 = db.Artists
            .Single(a => a.ArtistName == "Beyoncé");
            Console.WriteLine($"ArtistId: {artist2.ArtistId}, Namn: {artist2.ArtistName}");

            //Standardoperatorer

            var sortedAlbums = db.Albums.OrderBy(a => a.Title).ToList();
            Console.WriteLine("\nAlbum sorterade efter titel:");
            foreach (var album in sortedAlbums)
            {
                Console.WriteLine(album.Title);
            }

            var hasGenre = db.Genres.Any(g => g.GenreName == "Rock");
            Console.WriteLine($"\nFinns det några genrer? {hasGenre}");

            var allHaveArtist = db.Albums.All(a => a.FkArtistId != 0);
            Console.WriteLine($"Har alla album en artist kopplad? {allHaveArtist}");

            var firstArtist = db.Artists.First();
            Console.WriteLine($"\nFörsta artisten: {firstArtist.ArtistName}");

            //INNER JOIN
            var artistAlbums = db.Artists
            .Join(db.Albums,
            artist => artist.ArtistId,
            album => album.FkArtistId,
            (artist, album) => new { artist.ArtistName, album.Title })
            .ToList();
            Console.WriteLine("\nArtist & Album (join):");
            foreach (var artist in artistAlbums)
            {
                Console.WriteLine($"{artist.ArtistName} - {artist.Title}");
            }

            //GROUP JOIN
            var genreCounts = db.Genres
            .GroupJoin(db.Albums,
            genre => genre.GenreId,
            album => album.FkGenreId,
            (genre, album) => new { genre.GenreName, Count = album.Count() })
            .ToList();
            Console.WriteLine("\nAntal album per genre:");
            foreach (var genre in genreCounts)
            {
                Console.WriteLine($"{genre.GenreName}: {genre.Count}");
            }
        }
    }
}
