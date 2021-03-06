﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: Rendeles/Index
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var webPizzaAppDbContext = _context.Rendelesek.Include(r => r.Allapot)
                .Include(r => r.Futar)
                .Include(r => r.Cim)
                .Include(r => r.Cim.Megrendelo)
                .Include(r => r.PizzaRendelesek)
                .ThenInclude(r => r.Pizza)
                .Where(r => r.AllapotId < 3)
                .OrderByDescending(r => r.RendelesId);


            int pageSize = 4;
            return View(await PaginatedList<Rendeles>.CreateAsync(webPizzaAppDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Rendeles/Create
        public IActionResult Create()
        {
            // create session for pizzaid-k
            HttpContext.Session.SetString("pids", "");

            PopulateCimDropDownList();
            PopulatePizzaDropDownList();
            return View();
        }

        // POST: Rendeles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CimId")] Rendeles rendeles)
        {
            if (rendeles.CimId == null)
            {
                ModelState.AddModelError("Error", "A rendeléshez szükséges a megrendelő címe! ");
                PopulateCimDropDownList();
                PopulatePizzaDropDownList();
                return View(rendeles);
            }

            // pizzak osszeszedese
            var pizzakSessionbol = HttpContext.Session.GetString("pids");
            string[] pizzak = pizzakSessionbol.Split(' ');
            pizzak = pizzak.Take(pizzak.Count() - 1).ToArray();

            if (pizzak.Length == 0)
            {
                ModelState.AddModelError("Error", "A rendeléshez szükséges legalább egy pizzát hozzáadni! ");
                PopulateCimDropDownList();
                PopulatePizzaDropDownList();
                return View(rendeles);
            }

            if (ModelState.IsValid)
            {
                // uj rendeles
                rendeles.AllapotId = 1;
                _context.Add(rendeles);
                await _context.SaveChangesAsync();

                // pizzak hozzaad
                foreach (var p in pizzak)
                {
                    PizzaRendeles pr = new PizzaRendeles
                    {
                        PizzaId = int.Parse(p),
                        RendelesId = rendeles.RendelesId
                    };
                    _context.Add(pr);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            PopulateCimDropDownList();
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

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
                PopulateCimDropDownList();
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
            PopulateCimDropDownList();
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
            PopulateCimDropDownList();
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // POST: Rendeles/Lezar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Lezar(int id, [Bind("RendelesId,AllapotId,FutarId,CimId")] Rendeles rendeles)
        {
            if (id != rendeles.RendelesId)
            {
                return NotFound();
            }

            if (rendeles.AllapotId == 1)
            {
                ModelState.AddModelError("Error", "A rendelés nem zárható le, a pizza nincsen kiszállítva! ");
                ViewData["AllapotId"] = new SelectList(_context.Allapotok, "AllapotId", "Megnevezes", rendeles.AllapotId);
                PopulateCimDropDownList();
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
            PopulateCimDropDownList();
            ViewData["FutarId"] = new SelectList(_context.Futarok, "FutarId", "Nev", rendeles.FutarId);
            return View(rendeles);
        }

        // Megrendelők lenyíló lista feltöltése
        private void PopulateCimDropDownList()
        {
            ViewBag.CimId = GetMegrendelok();
        }

        // Pizzák lenyíló lista feltöltése
        private void PopulatePizzaDropDownList(object selectedPizza = null)
        {
            var pizzakQuery = from p in _context.Pizzak
                              orderby p.Nev
                              select p;
            ViewBag.PizzaId = new SelectList(pizzakQuery.AsNoTracking(), "PizzaId", "Nev", selectedPizza);
        }

        // Létezik e a rendelés
        private bool RendelesExists(int id)
        {
            return _context.Rendelesek.Any(e => e.RendelesId == id);
        }

        // Megrendelők címekkel lenyíló lista feltöltése
        public IEnumerable<SelectListItem> GetMegrendelok()
        {
            List<SelectListItem> megrendelok = _context.Cimek
                .Include(c => c.Megrendelo)
                .AsNoTracking()
                .Select(c =>
                    new SelectListItem
                    {
                        Value = c.CimId.ToString(),
                        Text = c.Megrendelo.Nev + ' ' + c.Irsz + ' ' + c.Varos + ' ' + c.Utca + ' ' + c.Hazszam
                    }).ToList();

            return new SelectList(megrendelok, "Value", "Text");
        }

        // Megrendelt pizzak a create formrol
        [HttpPost]
        public JsonResult MyajaxCall(string order)
        {
            HttpContext.Session.SetString("pids", order);
            return Json("ok");
        }
    }
}