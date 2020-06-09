using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelexpLogistikWebApp.Models
{
    public class User : IdentityUser
    {
        public string Other { get; set; }
    }
}
