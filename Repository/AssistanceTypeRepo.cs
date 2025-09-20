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
	public class AssistanceTypeRepo : BasicRepo<AssistanceType> , IAssistanceTypeRepo
	{
		public AssistanceTypeRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}

		public async Task<List<GetAssistanceTypeDto>> GetAssistanceTypesAsync()
		{
			return await GetAll().Select(x=> new GetAssistanceTypeDto
			{
				AssistanceTypeId = x.AssistanceTypeId,
				AssistanceTypeName = x.AssistanceTypeName,
				AssistanceValue = x.AssistanceValue,
				IsFinancial = x.IsFinancial,
				Assistances = x.Assistances.Select(x=> x.AssistanceId).ToList(),
			}).ToListAsync();
		}

		public async Task<GetAssistanceTypeDto?> GetByIdAsync(int id)
		{
			

			
			return await GetAll().Select(x => new GetAssistanceTypeDto
			{
				AssistanceTypeId = x.AssistanceTypeId,
				AssistanceTypeName = x.AssistanceTypeName,
				AssistanceValue = x.AssistanceValue,
				IsFinancial = x.IsFinancial,
				Assistances = x.Assistances.Select(x => x.AssistanceId).ToList()
			}).FirstOrDefaultAsync(x => x.AssistanceTypeId == id);
		}

		public async Task<AssistanceType?> GetEntityByIdAsync(int id)
		{



			return await GetAll().Include(x => x.Assistances).FirstOrDefaultAsync(x => x.AssistanceTypeId == id);
		}

		public async Task<List<GetAssistanceTypeDto>?> GetAssistanceTypePage(int page, int pageSize)
		{
			return await GetAll().Select(x => new GetAssistanceTypeDto
			{
				AssistanceTypeId = x.AssistanceTypeId,
				AssistanceTypeName = x.AssistanceTypeName,
				AssistanceValue = x.AssistanceValue,
				IsFinancial = x.IsFinancial,
				Assistances = x.Assistances.Select(x => x.AssistanceId).ToList()
			}).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task AddAssistanceTypeAsync(AssistanceType assistanceType)
		{
			Add(assistanceType);
			await SaveChangeAsync();

		}

		public async Task DeleteAssistanceTypeAsync(AssistanceType assistanceType)
		{
			

			Delete(assistanceType);
			await SaveChangeAsync();

		}

		public async Task UpdateAssistanceTypeAsync(AssistanceType assistanceType)
		{
			Update(assistanceType);
			
			await SaveChangeAsync();

		}

	}
}
