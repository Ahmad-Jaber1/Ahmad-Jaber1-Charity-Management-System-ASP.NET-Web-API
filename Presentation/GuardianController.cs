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
			await _guardianService.AddGuardianAsync(guardian);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateGuradian(string id , Guardian guardian)
		{
			var temp = await _guardianService.UpdateGuardianAsync(id, guardian);
			if (temp != null)
				return Ok();
			else 
				return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGuardian(string id)
		{
			var guardian = await _guardianService.DeleteGuardianAsync(id);
			if(guardian != null)
			return Ok();

			else 
				return NotFound();
		}


	}
}
