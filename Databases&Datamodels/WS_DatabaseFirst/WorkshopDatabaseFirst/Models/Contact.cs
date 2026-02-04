using System;
using System.Collections.Generic;

namespace WorkshopDatabaseFirst.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Birthday { get; set; }

    public int? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<ContactAdrress> ContactAdrresses { get; set; } = new List<ContactAdrress>();
}
