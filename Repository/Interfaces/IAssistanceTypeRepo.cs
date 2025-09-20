using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IAssistanceTypeRepo
	{
		Task<List<GetAssistanceTypeDto>> GetAssistanceTypesAsync();



		  Task<GetAssistanceTypeDto?> GetByIdAsync(int id);

		Task<AssistanceType?> GetEntityByIdAsync(int id);



		  Task AddAssistanceTypeAsync(AssistanceType assistanceType);



		  Task DeleteAssistanceTypeAsync(AssistanceType assistanceType);



		 Task UpdateAssistanceTypeAsync(AssistanceType assistanceType);

		Task<List<GetAssistanceTypeDto>?> GetAssistanceTypePage(int page, int pageSize);


	}
}
