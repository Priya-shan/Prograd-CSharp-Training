﻿using Microsoft.AspNetCore.Mvc;
using MVC_WebApllication.Models;
using System.Diagnostics;

namespace MVC_WebApllication.Controllers
{
    public class Home1Controller : Controller
    {
        private readonly ILogger<Home1Controller> _logger;

        public Home1Controller(ILogger<Home1Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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