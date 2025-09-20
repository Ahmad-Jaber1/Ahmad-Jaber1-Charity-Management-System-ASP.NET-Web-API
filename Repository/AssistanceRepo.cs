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
    public class AssistanceRepo : BasicRepo<Assistance>, IAssistanceRepo
	{
		public AssistanceRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}

		public async Task<List<GetAssistanceDto>> GetAssistanceAsync()
		{


			return await GetAll()
				.Select(x => new GetAssistanceDto
				{
					AssistanceId = x.AssistanceId,
					AssistanceTypeId = x.AssistanceTypeId,
					Date = x.Date,
					NumberOfAssistance = x.NumberOfAssistance,
					Note = x.Note,
					PersonId = x.PersonId,
					FamilyId = x.FamilyId,
					received = x.received
					
					
				}).ToListAsync();


		}

		public async Task<GetAssistanceDto?> GetByIdAsync(int id)
		{
			
			return await GetAll().Select(x => new GetAssistanceDto
			{
				AssistanceId = x.AssistanceId,
				AssistanceTypeId = x.AssistanceTypeId,
				Date = x.Date,
				NumberOfAssistance = x.NumberOfAssistance,
				Note = x.Note,
				PersonId = x.PersonId,
				FamilyId = x.FamilyId,
				received = x.received


			}).FirstOrDefaultAsync(x => x.AssistanceId == id);
		}

		public async Task<List<GetAssistanceDto>?> GetAssistancesPage(int page , int pageSize)
		{
			return await GetAll().Select(x => new GetAssistanceDto
			{
				AssistanceId = x.AssistanceId,
				AssistanceTypeId = x.AssistanceTypeId,
				Date = x.Date,
				NumberOfAssistance = x.NumberOfAssistance,
				Note = x.Note,
				PersonId = x.PersonId,
				FamilyId = x.FamilyId,
				received = x.received
			}).Skip((page-1) * pageSize).Take(pageSize).ToListAsync();
		}

		public async Task<Assistance?> GetEntityByIdAsync(int id)
		{

			return await GetAll().FirstOrDefaultAsync(x => x.AssistanceId == id);
		}

		public async Task AddAssistanceAsync(Assistance assistance)
		{
			Add(assistance);
			await SaveChangeAsync();

		}

		public async Task DeleteAssistanceAsync(Assistance assistance)
		{
			Delete(assistance);
			await SaveChangeAsync();

		}

		public async Task UpdateAssistanceAsync(Assistance assistance)
		{
			Update(assistance);

			await SaveChangeAsync();

		}
	}
}
