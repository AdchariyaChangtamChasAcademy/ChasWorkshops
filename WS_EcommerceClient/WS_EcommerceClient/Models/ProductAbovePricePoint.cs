using System;
using System.Collections.Generic;

namespace WS_EcommerceClient.Models;

public partial class ProductAbovePricePoint
{
    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }
}
