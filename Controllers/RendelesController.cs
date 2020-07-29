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
            var webPizzaAppDbContext = _context.Rendelesek.Include(r => r.Allapot)
                .Include(r => r.Futar)
                .Include(r => r.Cim)
                .Include(r => r.Cim.Megrendelo)
                .Include(r => r.PizzaRendelesek)
                .ThenInclude(r => r.Pizza);
            return View(await webPizzaAppDbContext.ToListAsync());
        }

        // GET: Teszt/Create
        public IActionResult CreateS1()
        {
            return View();
        }

        // POST: Teszt/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        // TODO - Új rendelés felvitel -> 
        // 1.
        // - rendelesId++ 
        // - AllapotId=1 
        // - pizzákat hozzáadni valahogy 
        // - cimId =  a megrendelő szűkített címei alapján 
        // - vissza a rendelésekhez, ekkor bekerül az aktuális rendelésekhez
        //
        // 2.
        // rendelések listában statusz váltás gomb hatására ->
        // - AllapotId=2 
        // - FutarId beállít ->
        // - vissza a rendelésekhez, ekkor módosul az aktuális rendelésekben
        //
        // 3.
        // rendelések listában újra statusz váltás gomb hatására ->
        // - AllapotId=3 

        // TODO - A rendelések index-ben a kilistázásban be kell tenni egy szűrést, h a kész ne látszódjon
    }
}
