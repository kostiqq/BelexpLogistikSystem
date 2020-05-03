using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Costumers
    {
        public Costumers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string CostumerName { get; set; }
        public int PhoneNumber { get; set; }
        public string CostumerEmail { get; set; }
        public string OtherInfo { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
