using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopArtistLibrary.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        // Foreign key till Artist
        public int FkArtistId { get; set; }
        [ForeignKey("FkArtistId")]
        public Artist Artist { get; set; }

        // Foreign key till Genre
        public int FkGenreId { get; set; }
        [ForeignKey("FkGenreId")]
        public Genre Genre { get; set; }
    }
}
