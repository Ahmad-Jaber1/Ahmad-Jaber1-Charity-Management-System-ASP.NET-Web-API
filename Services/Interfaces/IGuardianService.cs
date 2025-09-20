using Models.DTO;
using Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
	public interface IGuardianService
	{

		


		Task<List<GetGuardianDto>?> GetGuardiansAsync();

		Task<List<GetGuardianDto>?> GetGuardiansPageAsync(int page, int pageSize);

		Task<GetGuardianDto?> GetGuardianByIdAsync(string id);


		Task AddGuardianAsync(Guardian guardian);

		Task<Guardian?> UpdateGuardianAsync(string id, Guardian UpdatedGuardian);


		Task<Guardian?> DeleteGuardianAsync(string id);
		
	}
}
