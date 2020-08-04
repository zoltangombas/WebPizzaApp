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
        [Key]
        public int PizzaRendelesId { get; set; }

        [DisplayName("Rendelés")]
        public int RendelesId { get; set; }
        public Rendeles Rendeles { get; set; }

        [DisplayName("Pizza")]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}