using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Ride
    {
        public Ride()
        {
           
        }

        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int OrderId { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual Orders Order { get; set; }
    }
}
