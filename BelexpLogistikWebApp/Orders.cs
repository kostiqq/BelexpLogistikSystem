using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Orders
    {
        public Orders()
        {
            Ride = new HashSet<Ride>();
        }

        public int Id { get; set; }
        public int CostumerId { get; set; }
        public int GoodsId { get; set; }
        public int? DepartureCity { get; set; }
        public bool? IsComplete { get; set; }
        public int? WaybillId { get; set; }
        public string OtherInfo { get; set; }

        public virtual Costumers Costumer { get; set; }
        public virtual Cities DepartureCityNavigation { get; set; }
        public virtual Goods Goods { get; set; }
        public virtual Waybill Waybill { get; set; }
        public virtual ICollection<Ride> Ride { get; set; }
    }
}
