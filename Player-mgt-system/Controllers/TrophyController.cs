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
    public class TrophyController : Controller
    {
        private readonly PlayerContext _context;

        public TrophyController(PlayerContext context)
        {
            _context = context;
        }

        // GET: Trophy
        public async Task<IActionResult> Index()
        {
              return _context.Trophy != null ? 
                          View(await _context.Trophy.ToListAsync()) :
                          Problem("Entity set 'PlayerContext.Trophy'  is null.");
        }

        // GET: Trophy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.TrophyId == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // GET: Trophy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trophy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrophyId,TrophyName,StartDate,EndDate,Venue")] Trophy trophy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trophy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trophy);
        }

        // GET: Trophy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy.FindAsync(id);
            if (trophy == null)
            {
                return NotFound();
            }
            return View(trophy);
        }

        // POST: Trophy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrophyId,TrophyName,StartDate,EndDate,Venue")] Trophy trophy)
        {
            if (id != trophy.TrophyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trophy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrophyExists(trophy.TrophyId))
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
            return View(trophy);
        }

        // GET: Trophy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trophy == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophy
                .FirstOrDefaultAsync(m => m.TrophyId == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // POST: Trophy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trophy == null)
            {
                return Problem("Entity set 'PlayerContext.Trophy'  is null.");
            }
            var trophy = await _context.Trophy.FindAsync(id);
            if (trophy != null)
            {
                _context.Trophy.Remove(trophy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrophyExists(int id)
        {
          return (_context.Trophy?.Any(e => e.TrophyId == id)).GetValueOrDefault();
        }
    }
}
