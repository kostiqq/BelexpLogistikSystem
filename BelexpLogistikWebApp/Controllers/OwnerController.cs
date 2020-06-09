using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BelexpLogistikWebApp.Controllers
{
    public class OwnerController : Controller
    {
        BelexpLogistikContext db;
        public OwnerController(BelexpLogistikContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var owners = db.CarOwner;
            return View(owners);
        }
    }
}
