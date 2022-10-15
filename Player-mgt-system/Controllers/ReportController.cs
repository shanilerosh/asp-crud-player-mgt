using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;

namespace Player_mgt_system.Controllers;

public class ReportController : Controller
{
    private readonly PlayerContext _context;

    public ReportController(PlayerContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
       

        return View();
    }
    public  IActionResult  getReportData()
    {
        var listTrophy =  _context.Trophy.ToList();
        var listPlayer = _context.players.ToList();
        var listOwner = _context.Owner.ToList();
        var listTeam =  _context.Team.ToList();

        ReportDto reportDto = new ReportDto();
        reportDto.Owners = listOwner;
        reportDto.PlayersList = listPlayer;
        reportDto.Trophies = listTrophy;
        reportDto.Teams = listTeam;
        return Ok(reportDto);
    }
}