﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BelexpLogistikWebApp.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}