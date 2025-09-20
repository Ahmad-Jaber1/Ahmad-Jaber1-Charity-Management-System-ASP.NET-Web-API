using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
	public class FileResultModel
	{
		public byte[] FileBytes { get; set; }
		public string ContentType { get; set; }

		public string FileName { get; set; }
	}

}
