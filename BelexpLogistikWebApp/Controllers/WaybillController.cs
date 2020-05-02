using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelexpLogistikWebApp.Controllers
{
    public class WaybillController : Controller
    {
        BelexpLogistikContext db;
        public WaybillController(BelexpLogistikContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var waybills = db.Waybill.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Trailer);
            return View(waybills);
        }
        public IActionResult Info(int? id)
        {
            var waybills = db.Waybill.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Trailer);
            var waybill = waybills.Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
            return View(waybill);
        }
        public IActionResult CreateList()
        {
            return View();
        }
    }
}