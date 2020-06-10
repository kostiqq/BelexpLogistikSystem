using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CreateList()
        {
            return new ViewAsPdf();
        }
       
    }
}