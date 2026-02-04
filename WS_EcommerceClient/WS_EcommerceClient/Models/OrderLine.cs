using System;
using System.Collections.Generic;

namespace WS_EcommerceClient.Models;

public partial class OrderLine
{
    public int OrderLineId { get; set; }

    public int FkOrderId { get; set; }

    public int FkProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual OrderHeader FkOrder { get; set; } = null!;

    public virtual Product FkProduct { get; set; } = null!;
}
