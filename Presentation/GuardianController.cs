using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
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

	public class GuardianController : ControllerBase
	{
		private readonly IGuardianService _guardianService;

		public GuardianController(IGuardianService guardianService) 
		{
			_guardianService = guardianService;
		}

		[HttpGet]
		public async Task<IActionResult> GetGuardians()
		{
			var guardians = await _guardianService.GetGuardiansAsync();
			return Ok(guardians);
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetGuardians(int page = 1, int pageSize = 10)
		{
			List<GetGuardianDto>? guardians = await _guardianService.GetGuardiansPageAsync(page, pageSize);

			return Ok(guardians);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetGuardianById(string id)
		{
			var guardian = await _guardianService.GetGuardianByIdAsync(id);
			return Ok(guardian);
		}

		[HttpPost]
		public async Task<IActionResult> AddGuardian(Guardian guardian)
		{
			if (string.IsNullOrWhiteSpace(guardian.GuardianId))
			{
				return BadRequest("يرجى إدخال الرقم الوطني للوصي.");
			}

			var existing = await _guardianService.GetGuardianByIdAsync(guardian.GuardianId);
			if (existing != null)
			{
				return BadRequest("الرقم الوطني للوصي مسجل مسبقاً في النظام.");
			}

			try
			{
				await _guardianService.AddGuardianAsync(guardian);
				return Ok(new { guardianId = guardian.GuardianId });
			}
			catch (Exception)
			{
				return BadRequest("تعذر حفظ بيانات الوصي. يرجى التأكد من عدم تكرار الرقم الوطني وصحة البيانات.");
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateGuradian(string id , Guardian guardian)
		{
			var temp = await _guardianService.UpdateGuardianAsync(id, guardian);
			if (temp != null)
				return Ok();
			else 
				return NotFound("الوصي غير موجود.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGuardian(string id)
		{
			var existing = await _guardianService.GetGuardianByIdAsync(id);
			if (existing == null)
			{
				return NotFound("الوصي غير موجود أو تم حذفه مسبقاً.");
			}

			if (existing.PeopleUnderGuardianship != null && existing.PeopleUnderGuardianship.Count > 0)
			{
				return BadRequest("لا يمكن حذف الوصي لوجود أيتام مسجلين تحت وصايته.");
			}

			var guardian = await _guardianService.DeleteGuardianAsync(id);
			if (guardian != null)
				return Ok();
			else 
				return NotFound("الوصي غير موجود أو تم حذفه مسبقاً.");
		}


	}
}
