using Models;
using Models.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class FamilyService : IFamilyService
	{
		private readonly IFamilyRepo _familyRepo;

		public FamilyService(IFamilyRepo familyRepo) 
		{ 
			_familyRepo = familyRepo;
		}

		public async Task<List<GetFamilyDto>?> GetFamiliesAsync()
		{
			return await _familyRepo.GetFamiliesAsync();
		}

		public async Task<List<GetFamilyDto>?> GetFamiliesPageAsync(int page , int pageSize)
		{
			return await _familyRepo.GetFamilyPage(page , pageSize);
		}


		public async Task<GetFamilyDto?> GetFamilyByIdAsync(int id)
		{
			var family = await _familyRepo.GetFamilyByIdAsync(id);
			return family; 
		}

		public async Task AddFamilyAsync(Family family)
		{
			 await _familyRepo.AddFamilyAsync(family);
		}

		public async Task<Family?> UpdateFamilyAsync(int id , Family UpdatedFmaily)
		{
			var family = await _familyRepo.GetFamilyEntityByIdAsync(id);

			if(family != null)
			{
				family.Name = UpdatedFmaily.Name;
				family.NumberOfFamilyMembers = UpdatedFmaily.NumberOfFamilyMembers;
				family.IsHouseOwned = UpdatedFmaily.IsHouseOwned;
				await _familyRepo.UpdateFamilyAsync(family);

			}


			return family;
		}

		public async Task<Family?> DeleteFamilyAsync(int id )
		{
			var family = await _familyRepo.GetFamilyEntityByIdAsync(id);

			if(family != null && family.Assistances.Count > 0)
			{
				return new Family { FamilyId = 0 };
			}
			else if ( family != null ) 
			{ 
				await _familyRepo.DeleteFamilyAsync(family);
				return family; 
			}

			return family;
		}

	}
}
