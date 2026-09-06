using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Repository.Interfaces;
using Services;
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

	public class FamilyController : ControllerBase
	{
		private readonly IFamilyService _familyService;

		public FamilyController(IFamilyService familyService) 
		{ 
			_familyService = familyService;
		}

		[HttpGet]
		public async Task<IActionResult> GetFamilies()
		{
			var families = await _familyService.GetFamiliesAsync();
			return Ok(families);
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetFamilies(int page = 1, int pageSize = 10)
		{
			List<GetFamilyDto>? Families = await _familyService.GetFamiliesPageAsync(page, pageSize);

			return Ok(Families);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFamily(int id )
		{
			var family = await _familyService.GetFamilyByIdAsync(id);
			if(family == null) { return  NotFound(); }
			return Ok(family);
		}

		[HttpPost]
		public async Task<IActionResult> AddFamily(Family family)
		{
			if (string.IsNullOrWhiteSpace(family.Name))
			{
				return BadRequest("يرجى إدخال اسم الأسرة.");
			}

			try
			{
				await _familyService.AddFamilyAsync(family);
				return Ok(new { familyId = family.FamilyId });
			}
			catch (Exception)
			{
				return BadRequest("تعذر إضافة الأسرة. يرجى التحقق من صحة البيانات.");
			}
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateFamily(int id ,Family family)
		{
			var UpdatedFamily = await _familyService.UpdateFamilyAsync(id,family);

			if(UpdatedFamily == null) { return NotFound(); }
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFamily(int id )
		{
			var family = await _familyService.DeleteFamilyAsync(id);

			if (family == null) return NotFound("الأسرة غير موجودة أو تم حذفها مسبقاً.");
			else if (family.FamilyId == 0) return BadRequest("لا يمكن حذف الأسرة لوجود مساعدات مسجلة لها.");
			else return Ok();
		}

	}
}
