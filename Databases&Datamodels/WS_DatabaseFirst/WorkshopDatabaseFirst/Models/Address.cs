using System;
using System.Collections.Generic;

namespace WorkshopDatabaseFirst.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? PostalCode { get; set; }

    public string? Street { get; set; }

    public virtual ICollection<ContactAdrress> ContactAdrresses { get; set; } = new List<ContactAdrress>();
}
