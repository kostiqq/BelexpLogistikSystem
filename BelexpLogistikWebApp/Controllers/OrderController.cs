using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var orders = db.Orders.Include(p => p.Costumer).Include(p => p.Goods).Include(p => p.Ride);
            return View();
        }
    }
}