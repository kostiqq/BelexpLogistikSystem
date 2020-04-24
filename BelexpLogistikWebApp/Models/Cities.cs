using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Cities
    {
        public Cities()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public string Region { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
