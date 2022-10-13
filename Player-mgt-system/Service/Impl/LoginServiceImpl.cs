using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;

namespace Player_mgt_system.Service.Impl;

public class LoginServiceImpl : ILoginService
{
    
    private readonly PlayerContext _context;
    
    public LoginServiceImpl(PlayerContext context)
    {
        _context = context;
    }

    
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        
        //check if user is 
        var userData = await _context.Users.FirstOrDefaultAsync(obj => obj.Username == loginDto.UserName);

        if (null == userData)
        {
            throw new InvalidDataException("User not found with the username " + loginDto.UserName);
        }
        
        //validate if the password entered correctly
        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, userData.Password))
        {
            throw new InvalidDataException("Invalid Password for the user "+userData.Username);
        }

        return null;
    }
}