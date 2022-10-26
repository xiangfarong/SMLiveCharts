using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mw.SimulationCore.ClientHC.Models
{
	public class Data
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Year { get; set; }
		public double Value { get; set; }
		[DefaultValue("")]
		public string Comment { get; set; }
	}
}
