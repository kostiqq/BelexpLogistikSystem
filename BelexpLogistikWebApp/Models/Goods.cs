using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Goods
    {
        public Goods()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string GoodsName { get; set; }
        public double? GoodsWeight { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
