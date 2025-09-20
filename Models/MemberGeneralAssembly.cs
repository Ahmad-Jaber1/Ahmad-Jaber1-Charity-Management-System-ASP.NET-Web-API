using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class MemberGeneralAssembly : BasicMember
	{
		public bool IsAdministrativeMember { get; set; }
		public string ?AdministrativePosition { get; set; }

		public ICollection<Receipt> Receipts { get; set; } =new List<Receipt>();
	}
}
