using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
	public class Allapot
	{
		public int AllapotId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		[Required]
		[StringLength(50)]
		[DisplayName("Állapot")]
		public string Megnevezes { get; set; }

		public ICollection<Rendeles> Rendelesek { get; set; }
	}

}
