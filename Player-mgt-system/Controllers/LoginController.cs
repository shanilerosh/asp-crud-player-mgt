using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;

namespace Player_mgt_system.Controllers;

[Route("login")]
public class LoginController : Controller
{
    private readonly PlayerContext _context;

    public LoginController(PlayerContext context)
    {
        _context = context;
    }
    
    [Route("")]
    [Route("~/")]
    [Route("index")]
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        //check if user is 
        var userData = await _context.Users.FirstOrDefaultAsync(obj => obj.Username == loginDto.UserName);

        if (null == userData)
        {
            return await ShowMessageAndReturn("User Not found");
        }
        
        //validate if the password entered correctly
        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, userData.Password))
        {
            return await ShowMessageAndReturn("Invalid Password for the user "+userData.Username);
        }

        return RedirectToAction("Index", "Dashboard");
        //username not exist

    }

    private async Task<IActionResult> ShowMessageAndReturn(string customMessage)
    {
        TempData["Message"] = customMessage;
        TempData["hasError"] = "display: block";
        return RedirectToAction(nameof(Index));
    }
}