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
	public class AssistanceController :ControllerBase
	{
		private readonly IAssistanceService _assistanceService;

		public AssistanceController(IAssistanceService assistanceService) 
		{
			

			_assistanceService = assistanceService;
		}


		[HttpGet]
		public async Task< IActionResult> GetAssistances()
		{
			List<GetAssistanceDto>? Assistances =await _assistanceService.GetAssistancesAsync();
			
			return Ok(Assistances);
			
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetAssistances(int page = 1 , int pageSize = 10)
		{
			List<GetAssistanceDto>? Assistances = await _assistanceService.GetAssistancesPageAsync(page , pageSize);

			return Ok(Assistances);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAssistanceById(int id )
		{

			GetAssistanceDto? Assistance = await _assistanceService.GetAssistanceByIdAsync(id);
			if ( Assistance != null ) 
			return Ok(Assistance);
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddAssistance(AddAssistanceDTO assistance)
		{
			await _assistanceService.AddAssistancAsync(assistance);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAssistance (int id)
		{
			Assistance? Assistance = await _assistanceService.DeleteAssistanceAsync(id);
			if (Assistance != null)
				return Ok(Assistance);
			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateAssistance(int id, UpdateAssistanceDto assistance)
		{
			 await _assistanceService.UpdateAssistanceAsync(id, assistance);

			return Ok();
		}


	}
}
