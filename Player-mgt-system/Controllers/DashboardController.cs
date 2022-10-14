using Microsoft.AspNetCore.Mvc;
using Player_mgt_system.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Player_mgt_system.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PlayerContext _context;
        public DashboardController(ILogger<HomeController> logger,PlayerContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if(!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername))){
                return View();       
            }

            return RedirectToAction("Index", "Login");
        }
        
        public IActionResult    GetUserData()
        {
            HttpContext.Session.GetString("SessionVariables.SessionKeyUsername");
            var user =
                _context.Users.Where(obj => obj.Username.Equals(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername)));

            return Ok(user);
        }

    }
    
}