using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
    public class PizzaRendeles
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int RendelesId { get; set; }
        public Rendeles Rendeles { get; set; }


    }
}
