using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize(Roles = "Логист")]
        public ActionResult Delete(int id)
        {
            CarOwner carOwner = db.CarOwner.Find(id);
            if (carOwner == null)
            {
                return HttpNotFound();
            }
            return View(carOwner);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Логист")]
        public ActionResult DeleteConfirmed(int id)
        {
            CarOwner carOwner = db.CarOwner.Find(id);
            if (carOwner == null)
            {
                return HttpNotFound();
            }
            db.CarOwner.Remove(carOwner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit()
        {
            var owners = db.CarOwner;
            return View(owners);
        }
        [HttpGet]
        [Authorize(Roles = "Логист")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult Create(CarOwner carOwner)
        {
            db.CarOwner.Add(carOwner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
