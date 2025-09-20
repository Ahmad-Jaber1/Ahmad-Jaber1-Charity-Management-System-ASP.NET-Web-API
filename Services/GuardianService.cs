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
	public class GuardianService : IGuardianService
	{
		private readonly IGuardianRepo _guardianRepo;

		public GuardianService(IGuardianRepo guardianRepo) 
		{
			_guardianRepo = guardianRepo;
		}

		public async Task<List<GetGuardianDto>?> GetGuardiansAsync()
		{
			return await _guardianRepo.GetGuardiansAsync();

		}

		public async Task<List<GetGuardianDto>?> GetGuardiansPageAsync(int page, int pageSize)
		{
			return await _guardianRepo.GetGuardianPage(page , pageSize);

		}


		public async Task<GetGuardianDto?> GetGuardianByIdAsync(string id)
		{
			return await _guardianRepo.GetGuardianByIdAsync(id);
		}

		public async Task AddGuardianAsync(Guardian guardian)
		{
			await _guardianRepo.AddGuardian(guardian);
		}
		public async Task<Guardian?> UpdateGuardianAsync(string id, Guardian UpdatedGuardian)
		{
			var guardian = await _guardianRepo.GetGuardianEntityByIdAsync(id);

			if (guardian != null)
			{
				guardian.FirstName = UpdatedGuardian.FirstName;
				guardian.SecondName = UpdatedGuardian.SecondName;
				guardian.ThirdName = UpdatedGuardian.ThirdName;
				guardian.LastName = UpdatedGuardian.LastName;
				guardian.GuardianPhoneNumber = UpdatedGuardian.GuardianPhoneNumber;
				guardian.GuardianJob = UpdatedGuardian.GuardianJob;
				guardian.Relationship = UpdatedGuardian.Relationship;
				await _guardianRepo.UpdateGuardian(guardian);
				
			}

			return guardian; 
		}

		public async Task<Guardian?> DeleteGuardianAsync(string id)
		{
			var deletedGuardian = await _guardianRepo.GetGuardianEntityByIdAsync(id);

			if(deletedGuardian != null)
			{
				await _guardianRepo.DeleteGuardian(deletedGuardian) ;
				
			}
			return deletedGuardian;
		}
	}
}
