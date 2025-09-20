using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class GetFamilyDto
	{


		public int FamilyId { get; set; }
		[Required]

		[StringLength(100)]
		public string Name { get; set; }
		public int NumberOfFamilyMembers { get; set; }

		public bool IsHouseOwned { get; set; }

		public ICollection<string> FamilyMembers { get; set; } = new List<string>();
		public ICollection<int> Assistances { get; set; } = new List<int>();

	}
}
