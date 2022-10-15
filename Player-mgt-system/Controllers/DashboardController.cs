using Microsoft.AspNetCore.Mvc;
using Player_mgt_system.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;

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
        public IActionResult  GetDashboardData()
        {
            var teamCount = _context.Team.Count();
            var playerCount = _context.players.Count();
            var tropyCount = _context.Trophy.Count();
            var teamOwnersCount = _context.Owner.Count();

            DashboardDto dto = new DashboardDto();
            dto.TeamCount = teamCount;
            dto.PlayerCount = playerCount;
            dto.TrophyCount = tropyCount;
            dto.OwnerCount = teamOwnersCount;
            return Ok(dto);
        }
    }
    
}