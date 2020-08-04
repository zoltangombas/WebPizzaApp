using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
	public class Megrendelo
	{
		public int MegrendeloId { get; set; }

		[Column(TypeName = "nvarchar(100)")]
		[Required]
		[StringLength(100)]
		[DisplayName("Név")]
		public string Nev { get; set; }

		public ICollection<Cim> Cimek { get; set; }
	}
}
