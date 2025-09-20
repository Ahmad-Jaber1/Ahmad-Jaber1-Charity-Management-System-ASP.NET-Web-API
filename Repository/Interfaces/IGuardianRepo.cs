using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IGuardianRepo
	{
		Task<List<GetGuardianDto>> GetGuardiansAsync();



		 Task<GetGuardianDto?> GetGuardianByIdAsync(string id);



		 Task AddGuardian(Guardian guardian);


		 Task UpdateGuardian(Guardian guardian);



		 Task DeleteGuardian(Guardian guardian);


		Task<Guardian?> GetGuardianEntityByIdAsync(string id);

		Task<List<GetGuardianDto>?> GetGuardianPage(int page, int pageSize);
	}
}
