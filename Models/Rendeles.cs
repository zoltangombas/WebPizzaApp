using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
	public class Rendeles
	{
		public int RendelesId { get; set; }

		[DisplayName("Állapot")]
		[DisplayFormat(NullDisplayText = "Nincs elkezdve")]
		public int AllapotId { get; set; }
		public Allapot Allapot { get; set; }

		[DisplayName("Cím")]
		[DisplayFormat(NullDisplayText = "Nincs címhez rendelve")]
		public int? CimId { get; set; }
		public Cim Cim { get; set; }

		[DisplayName("Futár")]
		[DisplayFormat(NullDisplayText = "Nincs futárhoz rendelve")]
		public int? FutarId { get; set; }
		public Futar Futar { get; set; }
		public virtual IList<PizzaRendeles> PizzaRendelesek { get; set; }
	}
}