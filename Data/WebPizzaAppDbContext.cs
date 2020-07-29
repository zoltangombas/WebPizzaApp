using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
    public class WebPizzaAppDbContext : DbContext
    {
        public WebPizzaAppDbContext(DbContextOptions<WebPizzaAppDbContext> options) : base(options)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaRendeles>().HasKey(pr => new { pr.RendelesId, pr.PizzaId });

        }

        public DbSet<Allapot> Allapotok { get; set; }
        public DbSet<Cim> Cimek { get; set; }
        public DbSet<Futar> Futarok { get; set; }
        public DbSet<Megrendelo> Megrendelok { get; set; }
        public DbSet<Rendeles> Rendelesek { get; set; }
        public DbSet<Pizza> Pizzak { get; set; }
        public DbSet<PizzaRendeles> PizzaRendelesek { get; set; }
    }
}


