using System;
using System.Collections.Generic;

namespace Blazor_Autocomplete.Shared
{
    public partial class InternationalOrder
    {
        public long OrderId { get; set; }
        public string CustomsDescription { get; set; } = null!;
        public byte[] ExciseTax { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;
    }
}
