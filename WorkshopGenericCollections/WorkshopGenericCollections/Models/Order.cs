using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopGenericCollections.Models
{
    class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public override string ToString() => $"Order {Id} C:{CustomerId} P:{ProductId} @ {CreatedAt:t}";
    }
}
