using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
	public class Rendeles
	{
		public int RendelesId { get; set; }

		public int AllapotId { get; set; }
		public Allapot Allapot { get; set; }

		public int FutarId { get; set; }
		public Futar Futar { get; set; }

		public int CimId { get; set; }
		public Cim Cim { get; set; }

		public virtual IList<PizzaRendeles> PizzaRendelesek { get; set; }
	}
}