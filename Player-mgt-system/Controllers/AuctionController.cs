using Microsoft.AspNetCore.Mvc;
using Player_mgt_system.dto;
using Player_mgt_system.Models;

namespace Player_mgt_system.Controllers;

public class AuctionController : Controller
{
    private readonly PlayerContext _context;
    
    public AuctionController(PlayerContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        
        var trophies = _context.Trophy.Select(obj => new TrophyDto
        {
            TrophyId = obj.TrophyId,
            Venue = obj.Venue,
            EndDate = obj.EndDate,
            StartDate = obj.StartDate,
            TrophyName = obj.TrophyName,
            //remove already selected ones
        }).ToList();
        
        
        return View();
    }
}