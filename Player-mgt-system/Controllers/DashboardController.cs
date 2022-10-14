﻿using Microsoft.AspNetCore.Mvc;
using Player_mgt_system.Models;
using System.Diagnostics;

namespace Player_mgt_system.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DashboardController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername))){
                return View();       
            }

            return RedirectToAction("Index", "Login");
        }

    }
    
}