using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Cars
    {
        public Cars()
        {
            Ride = new HashSet<Ride>();
            Waybill = new HashSet<Waybill>();
        }

        public int Id { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string RegistrSign { get; set; }
        public double? CarMileage { get; set; }
        public DateTime? LastTechnicalInspection { get; set; }
        public int CarryingCapacity { get; set; }
        public double? FuelConsumption { get; set; }
        public int OwnerId { get; set; }

        public virtual CarOwner Owner { get; set; }
        public virtual ICollection<Ride> Ride { get; set; }
        public virtual ICollection<Waybill> Waybill { get; set; }
    }
}
