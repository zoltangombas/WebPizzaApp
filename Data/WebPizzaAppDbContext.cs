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
        { }

        public DbSet<Allapot> Allapotok { get; set; }
        public DbSet<Cim> Cimek { get; set; }
        public DbSet<Futar> Futarok { get; set; }
        public DbSet<Megrendelo> Megrendelok { get; set; }
        public DbSet<Rendeles> Rendelesek { get; set; }
        public DbSet<Pizza> Pizzak { get; set; }
        public DbSet<PizzaRendeles> PizzaRendelesek { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Pizzak
            var pizzak = new Pizza[]
            {
                new Pizza{PizzaId=1,Nev="Magyaros"},
                new Pizza{PizzaId=2,Nev="Húsos"},
                new Pizza{PizzaId=3,Nev="Szalámis"},
                new Pizza{PizzaId=4,Nev="Sajtos"},
                new Pizza{PizzaId=5,Nev="Mexikói"},
                new Pizza{PizzaId=6,Nev="Spenótos"},
                new Pizza{PizzaId=7,Nev="Sonkás"},
                new Pizza{PizzaId=8,Nev="Gombás"},
                new Pizza{PizzaId=9,Nev="Vega"},
            };
            modelBuilder.Entity<Pizza>().HasData(pizzak);


            //Allapotok
            var allapotok = new Allapot[]
            {
                new Allapot{AllapotId=1,Megnevezes="Készítés alatt"},
                new Allapot{AllapotId=2,Megnevezes="Kiszállítás alatt"},
                new Allapot{AllapotId=3,Megnevezes="Kiszállítva"},
            };
            modelBuilder.Entity<Allapot>().HasData(allapotok);


            //Futarok
            var futarok = new Futar[]
            {
                new Futar{FutarId=1,Nev="Villám Vili"},
                new Futar{FutarId=2,Nev="Lajhár Laci"},
                new Futar{FutarId=3,Nev="Gyors Gyuri"},
            };
            modelBuilder.Entity<Futar>().HasData(futarok);


            //Megrendelok
            var megrendelok = new Megrendelo[]
            {
                new Megrendelo{MegrendeloId=1,Nev="Éhes Elemér"},
                new Megrendelo{MegrendeloId=2,Nev="Éhes Eszter"},
                new Megrendelo{MegrendeloId=3,Nev="Hasas Hedvig"},
                new Megrendelo{MegrendeloId=4,Nev="Vega Viktor"},
                new Megrendelo{MegrendeloId=5,Nev="Vékony Vilma"},
            };
            modelBuilder.Entity<Megrendelo>().HasData(megrendelok);


            //Cimek
            var cimek = new Cim[]
            {
                new Cim{CimId=1,Irsz="1111",Varos="Budapest",Utca="Fehérvári út.",Hazszam="110", Csengo="20", MegrendeloId=1},
                new Cim{CimId=2,Irsz="1111",Varos="Budapest",Utca="Fehérvári út.",Hazszam="110", Csengo="20", MegrendeloId=2},
                new Cim{CimId=3,Irsz="2222",Varos="Budapest",Utca="Dózsa György út.",Hazszam="23", Csengo="3", MegrendeloId=3},
                new Cim{CimId=4,Irsz="3333",Varos="Budapest",Utca="István út.",Hazszam="45", Csengo="5", MegrendeloId=3},
                new Cim{CimId=5,Irsz="4444",Varos="Budapest",Utca="Attila út.",Hazszam="70", Csengo="11", MegrendeloId=4},
                new Cim{CimId=6,Irsz="5555",Varos="Budapest",Utca="Erzsébet út.",Hazszam="12", Csengo="10", MegrendeloId=5},
                new Cim{CimId=7,Irsz="6666",Varos="Budapest",Utca="Mária út.",Hazszam="24", Csengo="7", MegrendeloId=5},
                new Cim{CimId=8,Irsz="7777",Varos="Budapest",Utca="László út.",Hazszam="2", Csengo="2", MegrendeloId=5},
            };
            modelBuilder.Entity<Cim>().HasData(cimek);


            //Rendelesek
            var rendelesek = new Rendeles[]
            {
                new Rendeles{RendelesId=1,AllapotId=3,CimId=3,FutarId=1},
                new Rendeles{RendelesId=2,AllapotId=3,CimId=2,FutarId=1},
                new Rendeles{RendelesId=3,AllapotId=3,CimId=5,FutarId=2},
                new Rendeles{RendelesId=4,AllapotId=3,CimId=2,FutarId=3},
                new Rendeles{RendelesId=5,AllapotId=3,CimId=2,FutarId=3},
                new Rendeles{RendelesId=6,AllapotId=3,CimId=6,FutarId=3},
                new Rendeles{RendelesId=7,AllapotId=2,CimId=8,FutarId=2},
                new Rendeles{RendelesId=8,AllapotId=2,CimId=3,FutarId=1},
                new Rendeles{RendelesId=9,AllapotId=3,CimId=2,FutarId=1},
                new Rendeles{RendelesId=10,AllapotId=2,CimId=5,FutarId=2},
                new Rendeles{RendelesId=11,AllapotId=2,CimId=4,FutarId=2},
                new Rendeles{RendelesId=12,AllapotId=2,CimId=2,FutarId=1},
                new Rendeles{RendelesId=13,AllapotId=2,CimId=4,FutarId=1},
                new Rendeles{RendelesId=14,AllapotId=2,CimId=1,FutarId=3},
                new Rendeles{RendelesId=15,AllapotId=2,CimId=3,FutarId=2},
                new Rendeles{RendelesId=16,AllapotId=1,CimId=7},
                new Rendeles{RendelesId=17,AllapotId=1,CimId=7},
                new Rendeles{RendelesId=18,AllapotId=1,CimId=5},
            };
            modelBuilder.Entity<Rendeles>().HasData(rendelesek);


            //PizzaRendelesek
            var pizzaRendelesek = new PizzaRendeles[]
            {
                new PizzaRendeles{PizzaRendelesId=1,RendelesId=1,PizzaId=1},
                new PizzaRendeles{PizzaRendelesId=2,RendelesId=2,PizzaId=4},
                new PizzaRendeles{PizzaRendelesId=3,RendelesId=3,PizzaId=9},
                new PizzaRendeles{PizzaRendelesId=4,RendelesId=3,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=5,RendelesId=4,PizzaId=5},
                new PizzaRendeles{PizzaRendelesId=6,RendelesId=5,PizzaId=3},
                new PizzaRendeles{PizzaRendelesId=7,RendelesId=5,PizzaId=3},
                new PizzaRendeles{PizzaRendelesId=8,RendelesId=5,PizzaId=9},
                new PizzaRendeles{PizzaRendelesId=9,RendelesId=5,PizzaId=5},
                new PizzaRendeles{PizzaRendelesId=10,RendelesId=6,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=11,RendelesId=7,PizzaId=1},
                new PizzaRendeles{PizzaRendelesId=12,RendelesId=8,PizzaId=1},
                new PizzaRendeles{PizzaRendelesId=13,RendelesId=8,PizzaId=4},
                new PizzaRendeles{PizzaRendelesId=14,RendelesId=9,PizzaId=7},
                new PizzaRendeles{PizzaRendelesId=15,RendelesId=9,PizzaId=8},
                new PizzaRendeles{PizzaRendelesId=16,RendelesId=9,PizzaId=6},
                new PizzaRendeles{PizzaRendelesId=17,RendelesId=10,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=18,RendelesId=11,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=19,RendelesId=12,PizzaId=1},
                new PizzaRendeles{PizzaRendelesId=20,RendelesId=12,PizzaId=5},
                new PizzaRendeles{PizzaRendelesId=21,RendelesId=12,PizzaId=7},
                new PizzaRendeles{PizzaRendelesId=22,RendelesId=13,PizzaId=3},
                new PizzaRendeles{PizzaRendelesId=23,RendelesId=13,PizzaId=4},
                new PizzaRendeles{PizzaRendelesId=24,RendelesId=13,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=25,RendelesId=13,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=26,RendelesId=14,PizzaId=9},
                new PizzaRendeles{PizzaRendelesId=27,RendelesId=14,PizzaId=3},
                new PizzaRendeles{PizzaRendelesId=28,RendelesId=15,PizzaId=8},
                new PizzaRendeles{PizzaRendelesId=29,RendelesId=16,PizzaId=1},
                new PizzaRendeles{PizzaRendelesId=30,RendelesId=17,PizzaId=4},
                new PizzaRendeles{PizzaRendelesId=31,RendelesId=17,PizzaId=2},
                new PizzaRendeles{PizzaRendelesId=32,RendelesId=17,PizzaId=6},
                new PizzaRendeles{PizzaRendelesId=33,RendelesId=18,PizzaId=3},
                new PizzaRendeles{PizzaRendelesId=34,RendelesId=18,PizzaId=7},
            };
            modelBuilder.Entity<PizzaRendeles>().HasData(pizzaRendelesek);
        }
    }
}


