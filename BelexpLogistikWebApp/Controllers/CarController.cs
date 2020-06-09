using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelexpLogistikWebApp.Controllers
{
    public class CarController : Controller
    {
        BelexpLogistikContext db;
        public CarController(BelexpLogistikContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var cars = db.Cars.Include(p => p.Owner);
            return View(cars);
        }
    }
}
