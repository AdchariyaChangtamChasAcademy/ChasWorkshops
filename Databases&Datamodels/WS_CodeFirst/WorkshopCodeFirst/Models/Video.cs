using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopCodeFirst.Models
{
    public class Video
    {
        [Key]
        public int? VideoID { get; set; }
        public string? Title { get; set; }
        public int? Rating { get; set; }
        public string? Genre { get; set; }
        public string? VideoType { get; set; }
        public string? Actors { get; set; }
        public string? Directors { get; set; }
        public int? Duration { get; set; }
    }
}
