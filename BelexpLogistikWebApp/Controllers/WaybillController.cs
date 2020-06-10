using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace BelexpLogistikWebApp.Controllers
{
    public class WaybillController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        BelexpLogistikContext db;
        public WaybillController(BelexpLogistikContext context, IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            db = context;
        }
        public IActionResult Index()
        {
            var waybills = db.Waybill.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Trailers);
            return View(waybills);
        }  
        public IActionResult Info(int? id)
        {
            var waybills = db.Waybill.Include(p => p.Car).Include(p => p.Driver).Include(p => p.Trailers);
            var waybill = waybills.Where(p => p.Id == id).FirstOrDefault(p => p.Id == id);
            return View(waybill);
        }
        public IActionResult CreatePdf()
        {
            return new ViewAsPdf();
        }
        public IActionResult CreateList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Waybill waybill = db.Waybill.Find(id);
            if (waybill != null)
            {
                SelectList drivers = new SelectList(db.Drivers, "Id", "DriverSurname", waybill.DriverId);
                ViewBag.DriverId = drivers;
                SelectList cars = new SelectList(db.Cars, "Id", "CarModel", waybill.CarId);
                ViewBag.CarId = cars;
                SelectList trailers = new SelectList(db.Trailers, "Id", "TrailerModel", waybill.TrailersId);
                ViewBag.TrailersId = trailers;
                return View(waybill);
            }
            return RedirectToAction("Index");
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(Waybill waybill)
        {
            db.Entry(waybill).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}