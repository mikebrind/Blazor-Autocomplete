using System;
using System.Collections.Generic;

namespace Blazor_Autocomplete.Shared
{
    public partial class Territory
    {
        public Territory()
        {
            Employees = new HashSet<Employee>();
        }

        public long TerritoryId { get; set; }
        public string TerritoryDescription { get; set; } = null!;
        public long RegionId { get; set; }

        public virtual Region Region { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
