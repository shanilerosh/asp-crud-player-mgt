using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;
using Player_mgt_system.Service;

namespace Player_mgt_system.Controllers;

[Route("login")]
public class LoginController : Controller
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
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
        try
        {
            await _loginService.Login(loginDto);
            return RedirectToAction("Index", "Dashboard");
        }
        catch (InvalidDataException e)
        {
            return await ShowMessageAndReturn(e.Message);
        }
        catch (Exception e)
        {
            return await ShowMessageAndReturn("System Error. Please try again");
        }
    }

    private async Task<IActionResult> ShowMessageAndReturn(string customMessage)
    {
        TempData["Message"] = customMessage;
        TempData["hasError"] = "display: block";
        return RedirectToAction(nameof(Index));
    }
}