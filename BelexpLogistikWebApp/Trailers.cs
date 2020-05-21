using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Trailers
    {
        public Trailers()
        {
            Waybill = new HashSet<Waybill>();
        }

        public int Id { get; set; }
        public string TrailerModel { get; set; }
        public string RegisrtSign { get; set; }

        public virtual ICollection<Waybill> Waybill { get; set; }
    }
}
