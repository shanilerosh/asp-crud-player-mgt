using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Player_mgt_system.dto;
using Player_mgt_system.Models;

namespace Player_mgt_system.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        // GET: Player
        public async Task<IActionResult> Index()
        {
            //if(!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername))){
                return View(await _context.players.ToListAsync());       
            //}

            return RedirectToAction("Index", "Login");
        }

        // GET: Player/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var player = await _context.players
                .FirstOrDefaultAsync(m => m.PlayId == id);
            if (player == null)
            {
                return NotFound();
            }
            
            
            return View(player);
        }

        // GET: Player/Create
        public IActionResult Create()
        {
            //if(!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername))){
                return View();       
           // }

            return RedirectToAction("Index", "Login");
            
        }

        // POST: Player/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDto userDto)
        {
            //validate user
            bool isExist = _context.Users.Any(e => e.Username.Equals(userDto.UserName));

            if (isExist) {
                return NotFound("User Already Exist");
            }

            var user = new User();

            
            user.Username = userDto.UserName;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            user.role = "USER_PLAYER";
            user.AuthStatus= "NOT_AUTHORIZED";

            _context.Add(user);

            await _context.SaveChangesAsync();


            //create player
            var player = new Player();
            player.PlayerName = userDto.PlayerName;
            player.Description= userDto.Description;
            player.Speciality= userDto.Speciality;
            player.BasePrice= userDto.BasePrice;
            player.Country= userDto.Country;

            player.PlayerUser = user;


            _context.Add(player);


            await _context.SaveChangesAsync();

            return View();
        }

        // GET: Player/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var player = await _context.players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayId,PlayerName,Country,Speciality,Description,BasePrice")] Player player)
        {
            if (id != player.PlayId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.PlayId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.players == null)
            {
                return NotFound();
            }

            var player = await _context.players
                .FirstOrDefaultAsync(m => m.PlayId == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.players == null)
            {
                return Problem("Entity set 'PlayerContext.players'  is null.");
            }
            var player = await _context.players.FindAsync(id);
            if (player != null)
            {
                _context.players.Remove(player);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
          return _context.players.Any(e => e.PlayId == id);
        }
    }
    
}
