using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Receipt
	{
		[Key]
		public int ReceiptNO { get; set; }

		public int Value { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }

		public DateOnly? PaidDate { get; set; }

		
		public int BasicMemberId {  get; set; }


		public Member? Member { get; set; } 
		public MemberGeneralAssembly? MemberGeneralAssembly { get; set; }


	}
}
