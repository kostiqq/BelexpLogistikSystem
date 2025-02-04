﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BelexpLogistikWebApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BelexpLogistikWebApp.Controllers
{
    public class HomeController : Controller
    {
        UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        public IActionResult About()
        {
            return View("About");
        }
        public IActionResult Autopark()
        {
            return View("Autopark");
        }
        
        public IActionResult Service()
        {
            return View("Service");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
