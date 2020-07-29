using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _context.Rendelesek.ToListAsync());
        }
    }
}
