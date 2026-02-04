using System;
using System.Collections.Generic;

namespace WS_ConcertClient.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public decimal Price { get; set; }

    public int FkConcertId { get; set; }

    public virtual Concert FkConcert { get; set; } = null!;
}
