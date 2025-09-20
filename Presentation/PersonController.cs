using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin,Supervisor")]

	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}


		[HttpGet]
		public async Task<IActionResult> GetPeople()
		{
			List<GetPersonDto> people = await _personService.GetPeopleAsync();
			return Ok(people);
		}


		[HttpGet("GetPage")]
		public async Task<IActionResult> GetPeople(int page = 1, int pageSize = 10)
		{
			List<GetPersonDto>? people = await _personService.GetPeoplePageAsync(page, pageSize);

			return Ok(people);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPerson(string id)
		{
			GetPersonDto? person = await _personService.GetPersonByIdAsync(id);
			if (person != null)
				return Ok(person);
			return NotFound();

		}


		[HttpPost("AddPerson")]
		public async Task<IActionResult> AddPerson(Person person)
		{
			await _personService.AddPersonAsync(person);
			return Ok();
		}

		[HttpPost("AddOrphan")]
		public async Task<IActionResult> AddOrphan(AddOrphanDto orphan)
		{
			await _personService.AddOrphanAsync(orphan);
			return Ok();
		}

		[HttpPost("AddWidow")]

		public async Task<IActionResult> AddWidow(AddWidowDto widow)
		{
			await _personService.AddWidowAsync(widow);
			return Ok();
		}

		[HttpPost("AddPersonInFamily")]

		public async Task<IActionResult> AddPersonInFamily(AddPersonInFamily personInFamily, int familyId)
		{
			await _personService.AddPersonInFamily(personInFamily, familyId);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePerson(string id)
		{
			Person? deletedPerson = await _personService.DeletePersonAsync(id);

			if (deletedPerson != null && deletedPerson.Id != "")
			{
				Ok(deletedPerson);
			}
			else if (deletedPerson != null && deletedPerson.Id == "")
			{
				return BadRequest("Cannot delete this Person because they have Assistances.");
			}
			return NotFound();
		}

		[HttpPut ("{id}")]
		public async Task<IActionResult> UpdatePerson(string id , Person person)
		{
			await _personService.UpdatePerson(id, person);
			return Ok();
		}
		}
	}

