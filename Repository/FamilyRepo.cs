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
	public class FamilyRepo : BasicRepo<Family> ,IFamilyRepo
	{
		public FamilyRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}


		public async Task<List<GetFamilyDto>?> GetFamiliesAsync()
		{
			return await GetAll().Select(x => new GetFamilyDto
			{
				FamilyId = x.FamilyId,
				IsHouseOwned = x.IsHouseOwned,
				Name = x.Name,
				NumberOfFamilyMembers = x.NumberOfFamilyMembers,
				Assistances = x.Assistances.Select(y => y.AssistanceId).ToList(),
				FamilyMembers = x.FamilyMembers.Select(y => y.Id).ToList()

			}).ToListAsync();
		}
		public async Task<GetFamilyDto?> GetFamilyByIdAsync(int id)
		{
			return await GetAll().Select(x => new GetFamilyDto
			{
				FamilyId = x.FamilyId,
				IsHouseOwned = x.IsHouseOwned,
				Name = x.Name,
				NumberOfFamilyMembers = x.NumberOfFamilyMembers,
				Assistances = x.Assistances.Select(y => y.AssistanceId).ToList(),
				FamilyMembers = x.FamilyMembers.Select(y=> y.Id).ToList()

			}).FirstOrDefaultAsync( x => x.FamilyId == id);
		}

		public async Task<List<GetFamilyDto>?> GetFamilyPage(int page, int pageSize)
		{
			return await GetAll().Select(x => new GetFamilyDto
			{
				FamilyId = x.FamilyId,
				IsHouseOwned = x.IsHouseOwned,
				Name = x.Name,
				NumberOfFamilyMembers = x.NumberOfFamilyMembers,
				Assistances = x.Assistances.Select(y => y.AssistanceId).ToList(),
				FamilyMembers = x.FamilyMembers.Select(y => y.Id).ToList()

			}).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<Family?> GetFamilyEntityByIdAsync(int id)
		{
			return await GetAll().Include(x=>x.Assistances).FirstOrDefaultAsync(x => x.FamilyId == id);
		}

		public async Task AddFamilyAsync(Family family)
		{
			Add(family);
			await SaveChangeAsync();
		}

		public async Task UpdateFamilyAsync(Family family)
		{
			Update(family);
			await SaveChangeAsync();
		}
		public async Task DeleteFamilyAsync(Family family)
		{
			Delete(family);
			await SaveChangeAsync();
		}



	}
}
