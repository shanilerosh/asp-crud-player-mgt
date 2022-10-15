using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;
using Player_mgt_system.Service;

namespace Player_mgt_system.Controllers;

public class PlayertrophyController : Controller
{

    private readonly PlayerContext _context;
    private PlayerTrophyDto _playerTrophyDto;

    public PlayertrophyController(PlayerContext context)
    {
        _context = context;
    }
    
    
    public IActionResult Index()
    {

        var playerTrophyDto = new PlayerTrophyDto();
        
        //set current trophies
        var currentTrophies = _context.PlayerTrophies.ToList().
            Select(obj => FindFirstByTrophyId(obj.TrophyId)).ToList();


        var trophies = _context.Trophy.Select(obj => new TrophyDto
        {
            TrophyId = obj.TrophyId,
            Venue = obj.Venue,
            EndDate = obj.EndDate,
            StartDate = obj.StartDate,
            TrophyName = obj.TrophyName,
            //remove already selected ones
        }).ToList();
        
        var trophyDtos = trophies.Where(obj => !FindInList(obj.TrophyId, currentTrophies)).ToList();
        
        playerTrophyDto.TrophyDtos = trophyDtos;
        playerTrophyDto.CurrentTrophies = currentTrophies;
        
        return View(playerTrophyDto);
    }

    private bool FindInList(int id, List<TrophyDto> list)
    {
        return list.Any(obj => obj.TrophyId == id);
    }

    private TrophyDto FindFirstByTrophyId(int id)
    {
        var obj = _context.Trophy.FirstOrDefault(obj => obj.TrophyId == id);

        if (null == obj)
        {
            throw new Exception("Not found");
        }

        return new TrophyDto
        {

            TrophyId = obj.TrophyId,
            Venue = obj.Venue,
            EndDate = obj.EndDate,
            StartDate = obj.StartDate,
            TrophyName = obj.TrophyName,
        };
    }

    public async Task<IActionResult> Details(int? id)
    {

        if (id == null || _context.players == null)
        {
            return NotFound();
        }
        
        var trophy = await _context.Trophy.FindAsync(id);
        
        if (trophy == null)
        {
            return NotFound();
        }
        
        //Get Player Data
        //TODO -  change this to session id
        var player = await _context.players.FindAsync(1);
        
        if (player == null)
        {
            return NotFound();
        }
        
        var playerTrophy = new Player_Trophy();
        playerTrophy.Player = player;
        playerTrophy.Trophy = trophy;

         _context.Add(playerTrophy);
         
         await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }

    private PlayerTrophyDto GetDefaultModel()
    {
        var trophies = _context.Trophy.Select(obj => new TrophyDto
        {
            TrophyId = obj.TrophyId,
            Venue = obj.Venue,
            EndDate = obj.EndDate,
            StartDate = obj.StartDate,
            TrophyName = obj.TrophyName,
        }).ToList();

        var playerTrophyDto = new PlayerTrophyDto();
        playerTrophyDto.TrophyDtos = trophies;

        playerTrophyDto.Venue = "Test";

        return playerTrophyDto;
    }

    public async Task<IActionResult> Remove(int id)
    {
     
        if (id == null || _context.players == null)
        {
            return NotFound();
        }
        
        var trophy = await _context.Trophy.FindAsync(id);
        
        if (trophy == null)
        {
            return NotFound();
        }
        
        //Get Player Data
        //TODO -  change this to session id
        var player = await _context.players.FindAsync(1);


        var foundObj = _context.PlayerTrophies.ToList().Where(obj =>
            obj.TrophyId == id && obj.PlayerID == player.PlayId).First();
        
        if (foundObj == null)
        {
            return NotFound();
        }


        _context.PlayerTrophies.Remove(foundObj);
         
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));
    }
}