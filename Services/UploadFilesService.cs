using Microsoft.AspNetCore.Http;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Services
{
	public class UploadFilesService : IUploadFilesService
	{

		public UploadFilesService() { }


		public async Task UpoladFileForYear(int year, IFormFile file)
		{
			string extention = Path.GetExtension(file.FileName);

			string fileName = $"Budget_{year}" + extention;

			string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

			using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			Console.WriteLine(extention);
			Console.WriteLine(fileName);
			Console.WriteLine(path);


		}

		public async Task<FileResultModel?> GetFile(int year)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
			string fileName = Directory.GetFiles(path, $"Budget_{year}.*").FirstOrDefault();

			if (fileName == null) { return null; }

			string extention = Path.GetExtension(fileName);


			var bytes = await File.ReadAllBytesAsync(fileName);



			FileResultModel result = new FileResultModel() { FileBytes = bytes ,
				ContentType = "application/octet-stream"
			 , FileName =$"Budget_{year}"+extention};

			return result; 
		}

	}
}
