using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Users
    {
        public Users()
        {
            Drivers = new HashSet<Drivers>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public string Info { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Drivers> Drivers { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
