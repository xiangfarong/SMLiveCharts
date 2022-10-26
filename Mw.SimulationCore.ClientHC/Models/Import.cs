using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mw.SimulationCore.ClientHC.Models
{
	public class Import
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Year { get; set; }
		public string Country { get; set; }
		public int Tonnes { get; set; }
	}
}
