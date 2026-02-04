using WS_ConcertClient.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Runtime.InteropServices;

namespace WS_ConcertClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();
            var connectionString = builder.GetConnectionString("ConcertDB");
            var optionsBuilder = new DbContextOptionsBuilder<ConcertDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var options = optionsBuilder.Options;
            using var context = new ConcertDbContext(options);


            var artists = context.Artists;//.Where(a => a.Genre == "Pop").ToList();
            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.ArtistName}\n:: {artist.Genre}");
            }
        }
    }
}
