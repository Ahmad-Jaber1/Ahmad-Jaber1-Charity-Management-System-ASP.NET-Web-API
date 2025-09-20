
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services;
using Services.Interfaces;

namespace Presentation

{


	
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin,Supervisor")]


	public class AssistanceTypeController :ControllerBase
	{
		private readonly IAssistanceTypeService _assistanceTypeService;

		public AssistanceTypeController(IAssistanceTypeService assistanceTypeService) 
		{
			
			_assistanceTypeService = assistanceTypeService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAssistancType()
		{
			
			List<GetAssistanceTypeDto>? AssitanceType =await _assistanceTypeService.GetAssistanceTypesAsync();
			 
			return Ok(AssitanceType);
			
		}
		[HttpGet("GetPage")]
		public async Task<IActionResult> GetAssistancType(int page = 1, int pageSize = 10)
		{
			List<GetAssistanceTypeDto>? AssistanceType = await _assistanceTypeService.GetAssistanceTypesPageAsync(page, pageSize);

			return Ok(AssistanceType);

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAssistanceTyepById(int id)
		{
			GetAssistanceTypeDto? temp = await _assistanceTypeService.GetAssistanceTyepByIdAsync(id);

			if(temp != null)
			{
				return Ok(temp);
			}

			return NotFound();	
		}

		[HttpPost]
		public async Task<IActionResult> AddAssistancType(AssistanceType assistanceType)
		{
			await _assistanceTypeService.AddAssistanceType(assistanceType);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAssistanceType(int id)
		{
			AssistanceType? temp = await _assistanceTypeService.DeleteAssistanceType(id);

			if (temp != null && temp.AssistanceTypeId != 0)
				return Ok(temp);
			else if (temp != null && temp.AssistanceTypeId == 0)
				return BadRequest("Cannot delete AssistanceType because they have Assistances.");
			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAssistanceType(int id , AssistanceType assistanceTyep)
		{
			await _assistanceTypeService.UpdateAssistanceTypeAsync (id, assistanceTyep);
			return Ok();
		}

		
	}
}
