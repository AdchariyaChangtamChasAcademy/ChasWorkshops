using System;
using System.Collections.Generic;

namespace WorkshopDatabaseFirst.Models;

public partial class ContactAdrress
{
    public int ContactAddressId { get; set; }

    public DateOnly? ContactStartDate { get; set; }

    public DateOnly? ContactEndDate { get; set; }

    public int? FkContactId { get; set; }

    public int? FkAddressId { get; set; }

    public virtual Address? FkAddress { get; set; }

    public virtual Contact? FkContact { get; set; }
}
