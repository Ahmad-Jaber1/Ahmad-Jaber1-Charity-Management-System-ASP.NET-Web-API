using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
	public interface IFamilyService
	{

		Task<List<GetFamilyDto>?> GetFamiliesAsync();

		Task<List<GetFamilyDto>?> GetFamiliesPageAsync(int page, int pageSize);
		 Task<GetFamilyDto?> GetFamilyByIdAsync(int id);



		 Task AddFamilyAsync(Family family);



		 Task<Family?> UpdateFamilyAsync(int id, Family UpdatedFmaily);



		 Task<Family?> DeleteFamilyAsync(int id);
		
	}
}
