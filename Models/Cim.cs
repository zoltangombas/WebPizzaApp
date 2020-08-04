using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebPizzaApp.Data
{
	public class Cim
	{
		public int CimId { get; set; }

		[Column(TypeName = "nvarchar(10)")]
		[Required]
		[StringLength(4)]
		[DisplayName("Irányító szám")]
		public string Irsz { get; set; }

		[Column(TypeName = "nvarchar(200)")]
		[Required]
		[StringLength(200)]
		[DisplayName("Város")]
		public string Varos { get; set; }

		[Column(TypeName = "nvarchar(300)")]
		[Required]
		[StringLength(300)]
		[DisplayName("Utca")]
		public string Utca { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		[Required]
		[StringLength(50)]
		[DisplayName("Házszám")]
		public string Hazszam { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		[StringLength(50)]
		[DisplayName("Csengő")]
		public string Csengo { get; set; }

		[DisplayName("Megrendelő")]
		public int? MegrendeloId { get; set; }
		public Megrendelo Megrendelo { get; set; }
	}
}
