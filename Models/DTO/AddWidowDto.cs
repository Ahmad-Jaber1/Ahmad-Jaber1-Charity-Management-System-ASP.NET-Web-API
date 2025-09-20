using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class AddWidowDto
	{

		public string Id { get; set; }

		public string Gender { get; set; }

		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string ThirdName { get; set; }

		public string LastName { get; set; }


		public string? PhoneNumber { get; set; }


		public string EducationalLevel { get; set; }



		public string? Job { get; set; }


		public bool IsPartOfFamily { get; set; }
		public int? NumberOfFamilyMembers { get; set; }

		public bool? IsHouseOwned { get; set; }

		public string? GuardianId { get; set; }
		public int? FamilyId { get; set; }
	}
}
