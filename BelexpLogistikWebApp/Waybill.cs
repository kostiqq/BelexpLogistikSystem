using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BelexpLogistikWebApp
{
    public partial class Waybill
    {
        public Waybill()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShelfLifeFor { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public int? CarId { get; set; }
        public int? DriverId { get; set; }
        public int? TrailersId { get; set; }
        public string WaybillSeries { get; set; }

        public virtual Cars Car { get; set; }
        public virtual Drivers Driver { get; set; }
        public virtual Trailers Trailers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
