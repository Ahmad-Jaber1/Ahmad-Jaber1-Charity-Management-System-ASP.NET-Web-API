using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class AssistanceType
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AssistanceTypeId {  get; set; }
		[Required]

		[StringLength(250)]
		public string AssistanceTypeName { get; set; }

		public bool IsFinancial { get; set; }

		public int AssistanceValue { get; set; }

		public ICollection<Assistance> Assistances { get; set; } = new List<Assistance>();

		

	}
}