using System;
using System.Collections.Generic;

namespace WS_ConcertClient.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public string? Genre { get; set; }

    public virtual ICollection<Concert> Concerts { get; set; } = new List<Concert>();
}
