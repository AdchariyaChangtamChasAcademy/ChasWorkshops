using System;
using System.Collections.Generic;

namespace WS_ConcertClient.Models;

public partial class Concert
{
    public int ConcertId { get; set; }

    public DateOnly ConcertDate { get; set; }

    public int FkArtistId { get; set; }

    public int FkVenueId { get; set; }

    public virtual Artist FkArtist { get; set; } = null!;

    public virtual Venue FkVenue { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
