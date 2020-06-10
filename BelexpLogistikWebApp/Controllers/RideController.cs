using System;
using System.Linq;
using BelexpLogistikWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BelexpLogistikWebApp.Controllers
{
    public class RideController : Controller
    {
        UserManager<User> _userManager;
        BelexpLogistikContext db;
        public RideController(BelexpLogistikContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var rides = db.Ride.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Order);
            return View(rides);
        }
        [HttpGet]
        public ActionResult CreateRide()
        {
            SelectList drivers = new SelectList(db.Drivers.Where(p => p.IsFree == true), "Id", "DriverSurname");
            ViewBag.Drivers = drivers;
            SelectList orders = new SelectList(db.Orders.Where(p => p.IsComplete == false), "Id", "Id");
            ViewBag.Orders = orders;
            SelectList cars = new SelectList(db.Cars, "Id", "CarModel");
            ViewBag.Cars = cars;
            return View();
        }
        [HttpPost]
        public ActionResult CreateRide(Ride ride)
        {
            db.Ride.Add(ride);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DriverRides()
        {
            var user = User.Identity.Name;
            var rides = db.Ride.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Order).Where(p => p.Driver.Other == user);
            return View(rides);
        }
        [HttpGet]
        public ActionResult EditStatus(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Ride ride = db.Ride.Find(id);
            if (ride != null)
            {
                return View(ride);
            }
            return HttpNotFound();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult EditStatus(Ride ride)
        {
            db.Entry(ride).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("DriverRides");
        }
        public IActionResult Info(int? id)
        {
            var rides = db.Ride.Include(p => p.Order).Include(p => p.Driver).Include(p => p.Car);
            var ride = rides.Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
            return View(ride);
        }
    }
}
