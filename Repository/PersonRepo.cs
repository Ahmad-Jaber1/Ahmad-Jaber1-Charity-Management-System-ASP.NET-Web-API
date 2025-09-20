using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class PersonRepo : BasicRepo<Person>  , IPersonRepo
	{
		public PersonRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}

		public async Task<List<GetPersonDto>> GetPeopleAsync()
		{
			return await GetAll().Select(x => new GetPersonDto
			{
			PhoneNumber = x.PhoneNumber,
			NumberOfFamilyMembers = x.NumberOfFamilyMembers,
			IsPartOfFamily = x.IsPartOfFamily,
			Gender = x.Gender,
			Job = x.Job,
			EducationalLevel = x.EducationalLevel,
			FirstName = x.FirstName,
			LastName = x.LastName,
			SecondName = x.SecondName,
			ThirdName = x.ThirdName,
			IsWidow = x.IsWidow,
			IsOrphan = x.IsOrphan,
			IsHouseOwned = x.IsHouseOwned,
			Id = x.Id,
			FamilyId = x.FamilyId,
			GuardianId = x.GuardianId,
			Assistances = x.Assistances.Select(x=> x.AssistanceId).ToList()
		}).ToListAsync();
			

		}

		public async Task<GetPersonDto?> GetPersonById(string id)
		{
			return await GetAll().Select(x => new GetPersonDto
			{
				PhoneNumber = x.PhoneNumber,
				NumberOfFamilyMembers = x.NumberOfFamilyMembers,
				IsPartOfFamily = x.IsPartOfFamily,
				Gender = x.Gender,
				Job = x.Job,
				EducationalLevel = x.EducationalLevel,
				FirstName = x.FirstName,
				LastName = x.LastName,
				SecondName = x.SecondName,
				ThirdName = x.ThirdName,
				IsWidow = x.IsWidow,
				IsOrphan = x.IsOrphan,
				IsHouseOwned = x.IsHouseOwned,
				Id = x.Id,
				FamilyId = x.FamilyId,
				GuardianId = x.GuardianId,
				Assistances = x.Assistances.Select(x => x.AssistanceId).ToList()
			}).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Person?> GetPersonEntityById(string id)
		{
			return await GetAll().Include(x=>x.Assistances).FirstOrDefaultAsync(x => x.Id == id);
		}


		public async Task<List<GetPersonDto>?> GetPersonPage(int page, int pageSize)
		{
			return await GetAll().Select(x => new GetPersonDto
			{
				PhoneNumber = x.PhoneNumber,
				NumberOfFamilyMembers = x.NumberOfFamilyMembers,
				IsPartOfFamily = x.IsPartOfFamily,
				Gender = x.Gender,
				Job = x.Job,
				EducationalLevel = x.EducationalLevel,
				FirstName = x.FirstName,
				LastName = x.LastName,
				SecondName = x.SecondName,
				ThirdName = x.ThirdName,
				IsWidow = x.IsWidow,
				IsOrphan = x.IsOrphan,
				IsHouseOwned = x.IsHouseOwned,
				Id = x.Id,
				FamilyId = x.FamilyId,
				GuardianId = x.GuardianId,
				Assistances = x.Assistances.Select(x => x.AssistanceId).ToList()
			}).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
		}
		public async Task AddPersonAsync(Person person)
		{
			Add(person);
			await SaveChangeAsync();
		}

		public async Task UpdatePersonAsync(Person person)
		{
			Update(person);
			await SaveChangeAsync();
		}
		public async Task DeletePersonAsync(Person person)
		{
			Delete(person);
			await SaveChangeAsync();
		}
	}
}
