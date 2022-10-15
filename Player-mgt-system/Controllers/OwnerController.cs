using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.Models;

namespace Player_mgt_system.Controllers
{
    public class OwnerController : Controller
    {
        private readonly PlayerContext _context;

        public OwnerController(PlayerContext context)
        {
            _context = context;
        }

        public IActionResult GetOwners()
        {
            var owners =
                _context.Owner.Select(r=>r).ToList();

            return Ok(owners);
        }

       
    }
}
