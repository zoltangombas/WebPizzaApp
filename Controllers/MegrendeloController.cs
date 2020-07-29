using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPizzaApp.Data;

namespace WebPizzaApp.Controllers
{
    public class MegrendeloController : Controller
    {
        private readonly WebPizzaAppDbContext _context;

        public MegrendeloController(WebPizzaAppDbContext context)
        {
            _context = context;
        }

        // GET: Megrendelo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Megrendelok.ToListAsync());
        }

        // GET: Megrendelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var megrendelo = await _context.Megrendelok
                .FirstOrDefaultAsync(m => m.MegrendeloId == id);
            if (megrendelo == null)
            {
                return NotFound();
            }

            return View(megrendelo);
        }

        // GET: Megrendelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Megrendelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MegrendeloId,Nev")] Megrendelo megrendelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(megrendelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(megrendelo);
        }

        // GET: Megrendelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var megrendelo = await _context.Megrendelok.FindAsync(id);
            if (megrendelo == null)
            {
                return NotFound();
            }
            return View(megrendelo);
        }

        // POST: Megrendelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MegrendeloId,Nev")] Megrendelo megrendelo)
        {
            if (id != megrendelo.MegrendeloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(megrendelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MegrendeloExists(megrendelo.MegrendeloId))
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
            return View(megrendelo);
        }

        // GET: Megrendelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var megrendelo = await _context.Megrendelok
                .FirstOrDefaultAsync(m => m.MegrendeloId == id);
            if (megrendelo == null)
            {
                return NotFound();
            }

            return View(megrendelo);
        }

        // POST: Megrendelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var megrendelo = await _context.Megrendelok.FindAsync(id);
            _context.Megrendelok.Remove(megrendelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MegrendeloExists(int id)
        {
            return _context.Megrendelok.Any(e => e.MegrendeloId == id);
        }
    }
}
