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

	public class MemberController : ControllerBase
	{
		private readonly IMemberService _memberService;

		public MemberController(IMemberService memberService)
		{
			_memberService = memberService;
		}

		[HttpGet]
		public async Task<IActionResult> GetMembers()
		{
			var members = await _memberService.GetMembersAsync();
			return Ok(members);
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetMembersPage(int page = 1, int pageSize = 10)
		{
			var members = await _memberService.GetMembersPageAsync(page, pageSize);
			return Ok(members);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMemberById(string id)
		{
			var member = await _memberService.GetMemberByIdAsync(id);
			if (member != null)
				return Ok(member);
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddMember(AddMemberDto memberDto)
		{
			await _memberService.AddMemberAsync(memberDto);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMember(string id, UpdateMemberDto memberDto)
		{
			await _memberService.UpdateMemberAsync(id, memberDto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMember(string id)
		{
			var deleted = await _memberService.DeleteMemberAsync(id);

			if (deleted != null && deleted.Id == "0")
				return BadRequest("Cannot delete member because they have a Receipt.");
			else if (deleted != null)
				return Ok(deleted);

			return NotFound();
		}
	}
}
