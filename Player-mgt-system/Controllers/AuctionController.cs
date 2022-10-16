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
        var autionDto = new AutionDto();
        
        var trophies = _context.Trophy.Select(obj => new TrophyDto
        {
            TrophyId = obj.TrophyId,
            Venue = obj.Venue,
            EndDate = obj.EndDate,
            StartDate = obj.StartDate,
            TrophyName = obj.TrophyName,
            //remove already selected ones
        }).ToList();
        
        var team = _context.Team.Select(obj => new TeamDto
        {
            TeamId = obj.TeamId,
            TeamName = obj.TeamName,
            MaxPrice = obj.MaxPrice,
            TeamOwner = obj.TeamOwner,
            Description = obj.Description
        }).ToList();

        autionDto.TeamDtos = team;
        autionDto.TrophyDtos = trophies;
        
        return View(autionDto);
    }
    
    [HttpGet]
    public List<Player_Trophy>Test(int id)
    {
        var playerTrophies = _context
            .PlayerTrophies.Where(obj => obj.TrophyId.Equals(id)).ToList();

        return playerTrophies;
        
    }

    [HttpGet]
    public async Task<Player> GetPlayerById(int id)
    {
        return await _context.players.FindAsync(id);
    }


}