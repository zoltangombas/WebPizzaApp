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
    public class CimController : Controller
    {
        private readonly WebPizzaAppDbContext _context;

        public CimController(WebPizzaAppDbContext context)
        {
            _context = context;
        }

        // GET: Cim
        public async Task<IActionResult> Index()
        {
            var webPizzaAppDbContext = _context.Cimek.Include(c => c.Megrendelo);
            return View(await webPizzaAppDbContext.ToListAsync());
        }

        // GET: Cim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cim = await _context.Cimek
                .Include(c => c.Megrendelo)
                .FirstOrDefaultAsync(m => m.CimId == id);
            if (cim == null)
            {
                return NotFound();
            }

            return View(cim);
        }

        // GET: Cim/Create
        public IActionResult Create()
        {
            ViewData["MegrendeloId"] = new SelectList(_context.Megrendelok, "MegrendeloId", "Nev");
            return View();
        }

        // POST: Cim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CimId,Irsz,Varos,Utca,Hazszam,Csengo,MegrendeloId")] Cim cim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MegrendeloId"] = new SelectList(_context.Megrendelok, "MegrendeloId", "Nev", cim.MegrendeloId);
            return View(cim);
        }

        // GET: Cim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cim = await _context.Cimek.FindAsync(id);
            if (cim == null)
            {
                return NotFound();
            }
            ViewData["MegrendeloId"] = new SelectList(_context.Megrendelok, "MegrendeloId", "Nev", cim.MegrendeloId);
            return View(cim);
        }

        // POST: Cim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CimId,Irsz,Varos,Utca,Hazszam,Csengo,MegrendeloId")] Cim cim)
        {
            if (id != cim.CimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CimExists(cim.CimId))
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
            ViewData["MegrendeloId"] = new SelectList(_context.Megrendelok, "MegrendeloId", "Nev", cim.MegrendeloId);
            return View(cim);
        }

        // GET: Cim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cim = await _context.Cimek
                .Include(c => c.Megrendelo)
                .FirstOrDefaultAsync(m => m.CimId == id);
            if (cim == null)
            {
                return NotFound();
            }

            return View(cim);
        }

        // POST: Cim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cim = await _context.Cimek.FindAsync(id);
            _context.Cimek.Remove(cim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CimExists(int id)
        {
            return _context.Cimek.Any(e => e.CimId == id);
        }
    }
}
