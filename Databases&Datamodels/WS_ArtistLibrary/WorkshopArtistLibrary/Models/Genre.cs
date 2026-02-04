using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopArtistLibrary.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(50)]
        public string GenreName { get; set; }

        // Navigation property: en genre kan ha flera album
        public ICollection<Album> Albums { get; set; }
    }
}
