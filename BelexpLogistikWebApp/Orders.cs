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
        public string DepartureCity { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsComplete { get; set; }
        public string Email { get; set; }
        public int? WaybillId { get; set; }
        public string CostumerName { get; set; }
        public string GoodsName { get; set; }
        public double? GoodsWeight { get; set; }
        public string OtherInfo { get; set; }

        public virtual Waybill Waybill { get; set; }
        public virtual ICollection<Ride> Ride { get; set; }
    }
}
