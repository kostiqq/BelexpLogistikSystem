using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class CarOwner
    {
        public CarOwner()
        {
            Cars = new HashSet<Cars>();
        }

        public int Id { get; set; }
        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnerEmail { get; set; }
        public bool? IsEntity { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
