using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Person
	{
		[Required]
		public string Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Gender { get; set; }
		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(100)]
		public string SecondName { get; set; }
		[Required]
		[StringLength(100)]
		public string ThirdName { get; set; }
		[Required]
		[StringLength(100)]
		public string LastName { get; set; }
		

		public string? PhoneNumber { get; set; }

		[Required]
		[StringLength(100)]
		public string EducationalLevel { get; set; }

		public bool IsWidow {  get; set; }

		public bool IsOrphan { get; set; }
		[StringLength(100)]
		public string? Job { get; set; }


		public bool IsPartOfFamily { get; set; }
		public int ?NumberOfFamilyMembers {  get; set; }

		public bool ?IsHouseOwned { get; set; }

		public string? GuardianId { get; set; }
		public int? FamilyId { get; set; }

		public Guardian? Guardian { get; set; }

		public Family? Family { get; set; }

		public ICollection<Assistance> Assistances { get; set; } = new List<Assistance>();









	}
}
