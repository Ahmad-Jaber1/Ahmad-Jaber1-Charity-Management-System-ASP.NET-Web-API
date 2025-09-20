using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Guardian
	{
		[Key]
		public string GuardianId { get; set; }
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
		[Required]
		[StringLength(100)]
		public string Relationship { get; set; }
		[StringLength(100)]
		public string GuardianJob { get; set; }
		[StringLength(100)]
		public string GuardianPhoneNumber { get; set; }


		public ICollection<Person> PeopleUnderGuardianship { get; set; } = new List<Person>();
	}
}
