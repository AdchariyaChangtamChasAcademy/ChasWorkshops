using System;
using System.Collections.Generic;

namespace WS_EcommerceClient.Models;

public partial class OrdersByCity
{
    public int? Quantity { get; set; }

    public string City { get; set; } = null!;
}
