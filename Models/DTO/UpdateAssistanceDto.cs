using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class UpdateAssistanceDto
	{
		


			public int NumberOfAssistance { get; set; }
			public int? FamilyId { get; set; }


			public String? PersonId { get; set; }
			public int AssistanceTypeId { get; set; }

			


			public string? Note { get; set; }

		public bool received { get; set; } 






	}
}
