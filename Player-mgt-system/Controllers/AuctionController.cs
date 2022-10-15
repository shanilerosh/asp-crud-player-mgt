using Microsoft.AspNetCore.Mvc;
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
        return View();
    }
}