using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BelexpLogistikWebApp.Models;

namespace BelexpLogistikWebApp.Controllers
{
    public class DriverController : Controller
    {
        BelexpLogistikContext db;
        public DriverController(BelexpLogistikContext context)
        {
            db = context;
        }
        public IActionResult Drivers()
        {
            return View();
            ///return View(db.Drivers.ToList());
        }
    }
}