using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BelexpLogistikWebApp.Controllers
{
    public class OrderController : Controller
    {
        BelexpLogistikContext db;
        public OrderController(BelexpLogistikContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var orders = db.Orders.Include(p => p.Ride);
            return View(orders);
        }
        public IActionResult Info(int? id)
        {
            var orders = db.Orders.Include(p => p.Ride);
            var order = orders.Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
            return View(order);
        }
        public IActionResult InfoEnd(int? id)
        {
            var orders = db.Orders.Include(p => p.Ride);
            var order = orders.Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
            return View(order);
        }
        [HttpGet]
        public ActionResult CreateOrder()
        {
            return View("CreateOrder");
        }
        [HttpPost]
        public ActionResult CreateOrder(Orders order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return View("Complete");
        }
        [HttpGet]
        public ActionResult EditOrder(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Orders order = db.Orders.Find(id);
            if (order != null)
            {
                SelectList waybills = new SelectList(db.Waybill, "Id", "WaybillSeries", order.WaybillId);
                ViewBag.WaybillId = waybills;
                return View(order);
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditOrder(Orders order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}