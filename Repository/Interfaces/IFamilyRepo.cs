using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface  IFamilyRepo
	{
		Task<List<GetFamilyDto>?> GetFamiliesAsync();

		Task<GetFamilyDto?> GetFamilyByIdAsync(int id);


		Task<Family?> GetFamilyEntityByIdAsync(int id);


		Task AddFamilyAsync(Family family);


		Task UpdateFamilyAsync(Family family);

		Task DeleteFamilyAsync(Family family);

		Task<List<GetFamilyDto>?> GetFamilyPage(int page, int pageSize);

	}
}
