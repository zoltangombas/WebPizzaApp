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
    public class RendelesController : Controller
    {
        private readonly WebPizzaAppDbContext _context;

        public RendelesController(WebPizzaAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // TODO - A rendelések index-ben majd kilistázásban be kell tenni egy szűrést, h a kész ne látszódjon

            var webPizzaAppDbContext = _context.Rendelesek.Include(r => r.Allapot)
                .Include(r => r.Futar)
                .Include(r => r.Cim)
                .Include(r => r.Cim.Megrendelo)
                .Include(r => r.PizzaRendelesek)
                .ThenInclude(r => r.Pizza);
            return View(await webPizzaAppDbContext.ToListAsync());

        }

        // GET: Rendeles/Create
        public IActionResult Create()
        {
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam");
            //PopulateCimDropDownList();
            PopulatePizzaDropDownList();
            return View();
        }

        // POST: Rendeles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CimId,selectedPizza")] Rendeles rendeles, int SelectedPizza)
        {
            if (ModelState.IsValid)
            {
                rendeles.AllapotId = 1;
                _context.Add(rendeles);
                await _context.SaveChangesAsync();

                PizzaRendeles pr = new PizzaRendeles
                {
                    PizzaId = SelectedPizza,
                    RendelesId = rendeles.RendelesId
                };
                _context.Add(pr);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rendeles);
        }

        // GET: Rendeles/Addpizza
        public async Task<IActionResult> Addpizza(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendeles = await _context.Rendelesek.FindAsync(id);
            if (rendeles == null)
            {
                return NotFound();
            }
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // TODO - Rendeles/Addpizza : pizza hozzáadása a meglévő rendeléshez

        // POST: Rendeles/Addpizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addpizza(int id, [Bind("RendelesId,AllapotId,FutarId,CimId")] Rendeles rendeles)
        {
            if (id != rendeles.RendelesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendeles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendelesExists(rendeles.RendelesId))
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
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // GET: Rendeles/Kiszallit
        public async Task<IActionResult> Kiszallit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendeles = await _context.Rendelesek.FindAsync(id);
            if (rendeles == null)
            {
                return NotFound();
            }
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // TODO - Rendeles/Kiszallit : az AllapotId=2 ra változzon, Futar beállítása a rendeléshez

        // POST: Rendeles/Kiszallit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kiszallit(int id, [Bind("RendelesId,AllapotId,FutarId,CimId")] Rendeles rendeles)
        {
            if (id != rendeles.RendelesId)
            {
                return NotFound();
            }

            if (rendeles.AllapotId != 1)
            {
                ModelState.AddModelError("Error", "A rendelés nem szállítható ki, mert már kiszállítás alatt áll! ");
                ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
                ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
                ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
                return View(rendeles);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rendeles.AllapotId = 2;
                    _context.Update(rendeles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendelesExists(rendeles.RendelesId))
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
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // GET: Rendeles/Lezar
        public async Task<IActionResult> Lezar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendeles = await _context.Rendelesek.FindAsync(id);
            if (rendeles == null)
            {
                return NotFound();
            }
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // TODO - Rendeles/Lezar : az AllapotId=3 ra változzon

        // POST: Rendeles/Lezar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lezar(int id, [Bind("RendelesId,AllapotId,FutarId,CimId")] Rendeles rendeles)
        {
            if (id != rendeles.RendelesId)
            {
                return NotFound();
            }

            if (rendeles.AllapotId != 2)
            {
                ModelState.AddModelError("Error", "A rendelés nem zárható le, a pizza nincsen kiszállítva! ");
                ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
                ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
                ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
                return View(rendeles);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rendeles.AllapotId = 3;
                    _context.Update(rendeles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendelesExists(rendeles.RendelesId))
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
            ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
            ViewData["CimId"] = new SelectList(_context.Cimek, "CimId", "Hazszam", rendeles.CimId);
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // Megrendelők lenyíló lista feltöltése
        // TODO - CimId helyett a megrendelők neve és címei
        private void PopulateCimDropDownList()
        {
            var cim = _context.Cimek
                .Include(c => c.Megrendelo)
                .Where(c => c.CimId == c.Megrendelo.MegrendeloId);

            var cim2 = _context.Cimek.OrderBy(c => c.CimId);

            ViewBag.MCimId = new SelectList(cim.AsNoTracking(), "CimId", "Irsz");
        }

        // Pizzák lenyíló lista feltöltése
        private void PopulatePizzaDropDownList(object selectedPizza = null)
        {
            var pizzakQuery = from p in _context.Pizzak
                              orderby p.Nev
                              select p;
            ViewBag.PizzaId = new SelectList(pizzakQuery.AsNoTracking(), "PizzaId", "Nev", selectedPizza);
        }

        private bool RendelesExists(int id)
        {
            return _context.Rendelesek.Any(e => e.RendelesId == id);
        }

    }
}
