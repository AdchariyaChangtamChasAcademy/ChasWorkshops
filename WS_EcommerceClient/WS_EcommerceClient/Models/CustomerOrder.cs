using System;
using System.Collections.Generic;

namespace WS_EcommerceClient.Models;

public partial class CustomerOrder
{
    public string Customer { get; set; } = null!;

    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }
}
