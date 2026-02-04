using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopCodeFirst.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistID { get; set; }
        public string? Name { get; set; }
        [ForeignKey("VideoID")]
        public int FkVideoID { get; set; }
        public Video video;
    }
}
