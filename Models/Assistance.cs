using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Assistance
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AssistanceId {  get; set; }	 

		public int NumberOfAssistance { get; set; }
		public int? FamilyId { get; set; }


		public String ? PersonId { get; set; }
		public int AssistanceTypeId { get; set; }

		[StringLength(4000)]
		public string ?Note {  get; set; }

		public bool received { get; set; } 

		public DateOnly Date { get; set; }

		public Family ? Family { get; set; }
		public Person? Person { get; set; }

		public AssistanceType AssistanceType { get; set; }




		



	}
}
