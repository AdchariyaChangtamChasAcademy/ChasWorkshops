using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopProductFilter
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrWhiteSpace(Category) && Price >= 0);
        }
    }
}
