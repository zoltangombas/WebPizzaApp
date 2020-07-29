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
    public class FutarController : Controller
    {
        private readonly WebPizzaAppDbContext _context;

        public FutarController(WebPizzaAppDbContext context)
        {
            _context = context;
        }

        // GET: Futar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Futarok.ToListAsync());
        }

        // GET: Futar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futar = await _context.Futarok
                .FirstOrDefaultAsync(m => m.FutarId == id);
            if (futar == null)
            {
                return NotFound();
            }

            return View(futar);
        }

        // GET: Futar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Futar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FutarId,Nev")] Futar futar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(futar);
        }

        // GET: Futar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futar = await _context.Futarok.FindAsync(id);
            if (futar == null)
            {
                return NotFound();
            }
            return View(futar);
        }

        // POST: Futar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FutarId,Nev")] Futar futar)
        {
            if (id != futar.FutarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutarExists(futar.FutarId))
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
            return View(futar);
        }

        // GET: Futar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futar = await _context.Futarok
                .FirstOrDefaultAsync(m => m.FutarId == id);
            if (futar == null)
            {
                return NotFound();
            }

            return View(futar);
        }

        // POST: Futar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var futar = await _context.Futarok.FindAsync(id);
            _context.Futarok.Remove(futar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FutarExists(int id)
        {
            return _context.Futarok.Any(e => e.FutarId == id);
        }
    }
}
