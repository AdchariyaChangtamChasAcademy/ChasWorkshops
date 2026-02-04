using System;
using System.Collections.Generic;

namespace WS_EcommerceClient.Models;

public partial class OrderHeader
{
    public int OrderId { get; set; }

    public int FkCustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public virtual Customer FkCustomer { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
