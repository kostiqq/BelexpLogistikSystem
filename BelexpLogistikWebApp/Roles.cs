﻿using System;
using System.Collections.Generic;

namespace BelexpLogistikWebApp
{
    public partial class Roles
    {
        public Roles()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
