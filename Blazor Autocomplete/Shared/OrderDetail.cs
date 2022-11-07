using System;
using System.Collections.Generic;

namespace Blazor_Autocomplete.Shared
{
    public partial class OrderDetail
    {
        public long OrderDetailsId { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public byte[] UnitPrice { get; set; } = null!;
        public long Quantity { get; set; }
        public double Discount { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
