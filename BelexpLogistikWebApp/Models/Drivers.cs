using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Drivers
    {
        public Drivers()
        {
            Ride = new HashSet<Ride>();
            Waybill = new HashSet<Waybill>();
        }

        public int Id { get; set; }
        public string DriverSurname { get; set; }
        public string DriverName { get; set; }
        public string DriverPatronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public int? DriverCardId { get; set; }
        public DateTime? LastMedicalInspection { get; set; }
        public int IdentificationNumber { get; set; }

        public virtual ICollection<Ride> Ride { get; set; }
        public virtual ICollection<Waybill> Waybill { get; set; }
    }
}
