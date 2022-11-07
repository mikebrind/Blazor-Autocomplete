using System;
using System.Collections.Generic;

namespace Blazor_Autocomplete.Shared
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public long? SupplierId { get; set; }
        public long? CategoryId { get; set; }
        public string? QuantityPerUnit { get; set; }
        public byte[]? UnitPrice { get; set; }
        public long? UnitsInStock { get; set; }
        public long? UnitsOnOrder { get; set; }
        public long? ReorderLevel { get; set; }
        public byte[] Discontinued { get; set; } = null!;
        public byte[]? DiscontinuedDate { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
