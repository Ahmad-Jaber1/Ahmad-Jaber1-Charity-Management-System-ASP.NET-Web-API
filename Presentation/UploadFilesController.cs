using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{

	[ApiController]
	[Route("api/[controller]")]
	[Authorize(Roles = "Admin,Supervisor")]


	public class UploadFilesController : ControllerBase
	{
		private IUploadFilesService _uploadFiles;

		public UploadFilesController(IUploadFilesService uploadFiles) 
		{ 
		
			_uploadFiles = uploadFiles;
		}

		[HttpPost]
		public async Task<IActionResult> Upload(int year , IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("Where is the File ?");

			await _uploadFiles.UpoladFileForYear(year, file);
			return Ok();
		}
		[HttpGet]
		public async Task<IActionResult> Download(int year)
		{
			FileResultModel? file = await _uploadFiles.GetFile(year);

			if (file == null)
				return BadRequest($"Not found the file with year {year}");

			
			return File(file.FileBytes, file.ContentType, file.FileName);
		}

	}
}
