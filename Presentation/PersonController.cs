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
		private readonly IFamilyService _familyService;
		private readonly IGuardianService _guardianService;

		public PersonController(IPersonService personService, IFamilyService familyService, IGuardianService guardianService)
		{
			_personService = personService;
			_familyService = familyService;
			_guardianService = guardianService;
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
			if (string.IsNullOrWhiteSpace(person.Id))
			{
				return BadRequest("يرجى إدخال الرقم الوطني.");
			}

			var existing = await _personService.GetPersonByIdAsync(person.Id);
			if (existing != null)
			{
				return BadRequest("الرقم الوطني مسجل مسبقاً في النظام لمستفيد آخر.");
			}

			if (person.FamilyId.HasValue && person.FamilyId.Value > 0)
			{
				var family = await _familyService.GetFamilyByIdAsync(person.FamilyId.Value);
				if (family == null)
				{
					return BadRequest("الأسرة المحددة غير موجودة في النظام.");
				}
			}

			if (!string.IsNullOrWhiteSpace(person.GuardianId))
			{
				var guardian = await _guardianService.GetGuardianByIdAsync(person.GuardianId);
				if (guardian == null)
				{
					return BadRequest("الوصي المحدد غير موجود في النظام.");
				}
			}

			try
			{
				await _personService.AddPersonAsync(person);
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest("تعذر حفظ بيانات المستفيد. يرجى التحقق من صحة البيانات.");
			}
		}

		[HttpPost("AddOrphan")]
		public async Task<IActionResult> AddOrphan(AddOrphanDto orphan)
		{
			if (string.IsNullOrWhiteSpace(orphan.Id))
			{
				return BadRequest("يرجى إدخال الرقم الوطني.");
			}

			var existing = await _personService.GetPersonByIdAsync(orphan.Id);
			if (existing != null)
			{
				return BadRequest("الرقم الوطني مسجل مسبقاً في النظام لمستفيد آخر.");
			}

			if (orphan.FamilyId.HasValue && orphan.FamilyId.Value > 0)
			{
				var family = await _familyService.GetFamilyByIdAsync(orphan.FamilyId.Value);
				if (family == null)
				{
					return BadRequest("الأسرة المحددة غير موجودة في النظام.");
				}
			}

			if (!string.IsNullOrWhiteSpace(orphan.GuardianId))
			{
				var guardian = await _guardianService.GetGuardianByIdAsync(orphan.GuardianId);
				if (guardian == null)
				{
					return BadRequest("الوصي المحدد غير موجود في النظام.");
				}
			}

			try
			{
				await _personService.AddOrphanAsync(orphan);
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest("تعذر حفظ بيانات اليتيم. يرجى التحقق من صحة البيانات.");
			}
		}

		[HttpPost("AddWidow")]

		public async Task<IActionResult> AddWidow(AddWidowDto widow)
		{
			if (string.IsNullOrWhiteSpace(widow.Id))
			{
				return BadRequest("يرجى إدخال الرقم الوطني.");
			}

			var existing = await _personService.GetPersonByIdAsync(widow.Id);
			if (existing != null)
			{
				return BadRequest("الرقم الوطني مسجل مسبقاً في النظام لمستفيد آخر.");
			}

			if (widow.FamilyId.HasValue && widow.FamilyId.Value > 0)
			{
				var family = await _familyService.GetFamilyByIdAsync(widow.FamilyId.Value);
				if (family == null)
				{
					return BadRequest("الأسرة المحددة غير موجودة في النظام.");
				}
			}

			try
			{
				await _personService.AddWidowAsync(widow);
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest("تعذر حفظ بيانات الأرملة. يرجى التحقق من صحة البيانات.");
			}
		}

		[HttpPost("AddPersonInFamily")]

		public async Task<IActionResult> AddPersonInFamily(AddPersonInFamily personInFamily, int familyId)
		{
			if (string.IsNullOrWhiteSpace(personInFamily.Id))
			{
				return BadRequest("يرجى إدخال الرقم الوطني.");
			}

			var existing = await _personService.GetPersonByIdAsync(personInFamily.Id);
			if (existing != null)
			{
				return BadRequest("الرقم الوطني مسجل مسبقاً في النظام لمستفيد آخر.");
			}

			var family = await _familyService.GetFamilyByIdAsync(familyId);
			if (family == null)
			{
				return BadRequest("الأسرة المحددة غير موجودة في النظام.");
			}

			try
			{
				await _personService.AddPersonInFamily(personInFamily, familyId);
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest("تعذر إضافة الفرد إلى الأسرة. يرجى التحقق من البيانات.");
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePerson(string id)
		{
			Person? deletedPerson = await _personService.DeletePersonAsync(id);

			if (deletedPerson != null && deletedPerson.Id != "")
			{
				return Ok(deletedPerson);
			}
			else if (deletedPerson != null && deletedPerson.Id == "")
			{
				return BadRequest("لا يمكن حذف هذا المستفيد لوجود مساعدات مسجلة له.");
			}
			return NotFound("المستفيد غير موجود أو تم حذفه مسبقاً.");
		}

		[HttpPut ("{id}")]
		public async Task<IActionResult> UpdatePerson(string id , Person person)
		{
			try
			{
				var updated = await _personService.UpdatePerson(id, person);
				if (updated == null)
				{
					return NotFound("المستفيد غير موجود.");
				}
				return Ok();
			}
			catch (Exception)
			{
				return BadRequest("تعذر تحديث بيانات المستفيد. يرجى التحقق من صحة البيانات.");
			}
		}
	}
	}

