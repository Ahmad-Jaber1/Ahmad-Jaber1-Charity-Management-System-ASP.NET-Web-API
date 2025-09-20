using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Member : BasicMember
	{

		

		public bool IsMembershipPaid { get; set; }

		public int? ReceiptId { get; set; }
		public Receipt? Receipt { get; set; }




	}
}
