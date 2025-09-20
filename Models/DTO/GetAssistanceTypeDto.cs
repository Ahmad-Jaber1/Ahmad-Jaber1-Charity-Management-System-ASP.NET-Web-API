using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class GetAssistanceTypeDto
	{

		public int AssistanceTypeId { get; set; }
		

		[StringLength(250)]
		public string AssistanceTypeName { get; set; }

		public bool IsFinancial { get; set; }

		public int AssistanceValue { get; set; }

		public ICollection<int> Assistances { get; set; } = new List<int>();
	}
}
