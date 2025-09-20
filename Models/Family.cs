using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Family
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int FamilyId {  get; set; }
		[Required]

		[StringLength(100)]
		public string Name { get; set; }
		public int NumberOfFamilyMembers { get; set; }

		public bool IsHouseOwned { get; set; }

		public ICollection<Person> FamilyMembers { get; set; } = new List<Person>();
		public ICollection<Assistance> Assistances { get; set; } = new List<Assistance>();

	}
}
