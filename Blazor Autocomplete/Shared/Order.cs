using System;
using System.Collections.Generic;

namespace Blazor_Autocomplete.Shared
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderId { get; set; }
        public string? CustomerId { get; set; }
        public long? EmployeeId { get; set; }
        public byte[]? OrderDate { get; set; }
        public byte[]? RequiredDate { get; set; }
        public byte[]? ShippedDate { get; set; }
        public byte[]? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual InternationalOrder? InternationalOrder { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
