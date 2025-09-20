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
	public class GuardianRepo : BasicRepo<Guardian> , IGuardianRepo
	{
		public GuardianRepo(CharityDbContex charityDbContex) : base(charityDbContex) { }


		public async Task<List<GetGuardianDto>> GetGuardiansAsync()
		{
			return await GetAll().Select(x => new GetGuardianDto
			{
				GuardianId = x.GuardianId,
				FirstName = x.FirstName,
				LastName = x.LastName,
				SecondName = x.SecondName,
				ThirdName = x.ThirdName,
				GuardianJob = x.GuardianJob,
				GuardianPhoneNumber = x.GuardianPhoneNumber,
				Relationship = x.Relationship,
				PeopleUnderGuardianship = x.PeopleUnderGuardianship.Select(y => y.Id).ToList(),
			}).ToListAsync();
		}


		public async Task<List<GetGuardianDto>?> GetGuardianPage(int page, int pageSize)
		{
			return await GetAll().Select(x => new GetGuardianDto
			{
				GuardianId = x.GuardianId,
				FirstName = x.FirstName,
				LastName = x.LastName,
				SecondName = x.SecondName,
				ThirdName = x.ThirdName,
				GuardianJob = x.GuardianJob,
				GuardianPhoneNumber = x.GuardianPhoneNumber,
				Relationship = x.Relationship,
				PeopleUnderGuardianship = x.PeopleUnderGuardianship.Select(y => y.Id).ToList(),
			}).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
		}
		public async Task<GetGuardianDto?> GetGuardianByIdAsync(string id)
		{
			return await GetAll().Select(x => new GetGuardianDto
			{
				GuardianId = x.GuardianId,
				FirstName = x.FirstName,
				LastName = x.LastName,
				SecondName = x.SecondName,
				ThirdName = x.ThirdName,
				GuardianJob = x.GuardianJob,
				GuardianPhoneNumber = x.GuardianPhoneNumber,
				Relationship = x.Relationship,
				PeopleUnderGuardianship = x.PeopleUnderGuardianship.Select(y => y.Id).ToList()
			}).FirstOrDefaultAsync(x => x.GuardianId == id);
		}

		public async Task<Guardian?> GetGuardianEntityByIdAsync(string id )
		{
			var guardian = await GetAll().FirstOrDefaultAsync(x => x.GuardianId == id);
			return guardian;	
		}

		public async Task AddGuardian(Guardian guardian)
		{
			
			 Add(guardian);
			await SaveChangeAsync();
		}
		public async Task UpdateGuardian(Guardian guardian)
		{

			Update(guardian);
			await SaveChangeAsync();
		}

		public async Task DeleteGuardian(Guardian guardian)
		{

			Delete(guardian);
			await SaveChangeAsync();
		}
	}
}
