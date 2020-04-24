using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class FuelForRide
    {
        public int Id { get; set; }
        public int? RideId { get; set; }
        public int? WayBillId { get; set; }
        public int? FuelingId { get; set; }

        public virtual Ride Ride { get; set; }
    }
}
