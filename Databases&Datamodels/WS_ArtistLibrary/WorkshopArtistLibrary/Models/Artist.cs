using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopArtistLibrary.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ArtistName { get; set; }

        // Navigation property: en artist kan ha flera album
        public ICollection<Album> Albums { get; set; }
    }
}
