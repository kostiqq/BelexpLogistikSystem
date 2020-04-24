using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<Cities>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
