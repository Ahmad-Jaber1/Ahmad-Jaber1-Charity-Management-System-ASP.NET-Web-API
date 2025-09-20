using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public  class BasicMember
	{

		[Key]
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public string LastName { get; set; }

		public string Location { get; set; }

		public string? PhoneNumber { get; set; }


		
	}
}
