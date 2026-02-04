using System;
using System.Collections.Generic;

namespace WS_ConcertClient.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string VenueName { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Concert> Concerts { get; set; } = new List<Concert>();
}
