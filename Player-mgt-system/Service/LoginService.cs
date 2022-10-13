using Microsoft.AspNetCore.Mvc;
using Player_mgt_system.dto;

namespace Player_mgt_system.Service;

public interface ILoginService
{
     Task<IActionResult> Login(LoginDto loginDto);
}