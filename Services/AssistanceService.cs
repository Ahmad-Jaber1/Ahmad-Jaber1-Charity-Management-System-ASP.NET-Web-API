using Models;
using Models.DTO;
using Repository;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AssistanceService : IAssistanceService
	{
		private readonly IAssistanceRepo _assistanceRepo;
		private readonly IAssistanceTypeRepo _assistanceTypeRepo;


		public AssistanceService(IAssistanceRepo assistanceRepo , IAssistanceTypeRepo assistanceTypeRepo) 
		{
			_assistanceRepo = assistanceRepo;
			_assistanceTypeRepo = assistanceTypeRepo; 
		}

		public async Task<List<GetAssistanceDto>?> GetAssistancesAsync()
		{
			var getAssistancesDto = await _assistanceRepo.GetAssistanceAsync();
			return getAssistancesDto;
		}

		public async Task<List<GetAssistanceDto>?> GetAssistancesPageAsync(int page , int pageSize)
		{
			var getAssistancesDto = await _assistanceRepo.GetAssistancesPage(page , pageSize);
			return getAssistancesDto;
		}

		public async Task<GetAssistanceDto?> GetAssistanceByIdAsync(int id)
		{
			GetAssistanceDto? Assistance = await _assistanceRepo.GetByIdAsync(id);
			return Assistance;
		}

		public async Task AddAssistancAsync(AddAssistanceDTO assistanceDTO)
		{
			Assistance assistance = new Assistance();
			assistance.Date = DateOnly.FromDateTime(DateTime.Today);
			assistance.NumberOfAssistance = assistanceDTO.NumberOfAssistance;
			assistance.AssistanceTypeId = assistanceDTO.AssistanceTypeId;
			assistance.received = assistanceDTO.received; 
			//AssistanceType? assistanceType =await _assistanceTypeRepo.GetByIdAsync(assistance.AssistanceTypeId);

			//if(assistanceType != null ) { assistance.AssistanceType = assistanceType; }

			if(assistanceDTO.Note != null) 
				assistance.Note = assistanceDTO.Note;


			if (assistanceDTO.FamilyId != null)
				assistance.FamilyId = assistanceDTO.FamilyId;

			if (assistanceDTO.PersonId != null)
				assistance.PersonId = assistanceDTO.PersonId;
			await _assistanceRepo.AddAssistanceAsync(assistance);
		}

		public async Task<Assistance?> DeleteAssistanceAsync(int id)
		{
			Assistance? DeletedAssistance = await _assistanceRepo.GetEntityByIdAsync(id);

			if(DeletedAssistance != null)
			{
				await _assistanceRepo.DeleteAssistanceAsync(DeletedAssistance);
			}
			return DeletedAssistance;
		}


		public async Task UpdateAssistanceAsync(int id , UpdateAssistanceDto assistance)
		{
			Assistance? Current = await _assistanceRepo.GetEntityByIdAsync(id);
			if(Current != null)
			{
				Current.NumberOfAssistance = assistance.NumberOfAssistance;
				Current.received = assistance.received;
				Current.Note = assistance.Note;	
				Current.PersonId = assistance.PersonId;
				Current.FamilyId = assistance.FamilyId;
				Current.AssistanceTypeId = assistance.AssistanceTypeId;
				

				await _assistanceRepo.UpdateAssistanceAsync(Current);
			}

			
		}
	}
}
