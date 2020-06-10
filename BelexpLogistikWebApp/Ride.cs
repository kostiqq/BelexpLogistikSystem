using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BelexpLogistikWebApp
{
    public partial class Ride
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ArrivalDate { get; set; }
        public bool IsComplete { get; set; }
        public int? OrderId { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual Orders Order { get; set; }
    }
}
