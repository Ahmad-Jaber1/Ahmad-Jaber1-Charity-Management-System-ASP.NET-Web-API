using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interfaces;

namespace Presentation
{
	[ApiController]
	[Route("api/[controller]")]

	[Authorize(Roles = "Admin,Supervisor")]

	public class MemberGeneralAssemblyController : ControllerBase
	{
		private readonly IMemberGeneralAssemblyService _generalService;

		public MemberGeneralAssemblyController(IMemberGeneralAssemblyService generalService)
		{
			_generalService = generalService;
		}

		[HttpGet]
		public async Task<IActionResult> GetGeneralMembers()
		{
			var members = await _generalService.GetGeneralMembersAsync();
			return Ok(members);
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetGeneralMembersPage(int page = 1, int pageSize = 10)
		{
			var members = await _generalService.GetGeneralMembersPageAsync(page, pageSize);
			return Ok(members);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetGeneralMemberById(string id)
		{
			var member = await _generalService.GetGeneralMemberByIdAsync(id);
			if (member != null)
				return Ok(member);
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddGeneralMember(AddGeneralMemberDto dto)
		{
			await _generalService.AddGeneralMemberAsync(dto);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateGeneralMember(string id, UpdateGeneralMemberDto dto)
		{
			await _generalService.UpdateGeneralMemberAsync(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGeneralMember(string id)
		{
			var result = await _generalService.DeleteGeneralMemberAsync(id);

			if (result != null && result.Id == "0")
				return BadRequest("Cannot delete general member because they have Receipts.");
			else if (result != null)
				return Ok(result);

			return NotFound();
		}
	}
}
