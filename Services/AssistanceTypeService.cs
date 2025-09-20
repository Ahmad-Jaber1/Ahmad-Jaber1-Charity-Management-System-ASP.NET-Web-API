using Models;
using Models.DTO;
using Repository;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class AssistanceTypeService : IAssistanceTypeService
	{
		private readonly IAssistanceTypeRepo _assistanceTyperepo;

		public AssistanceTypeService(IAssistanceTypeRepo AssistanceTyperepo)
		{
			_assistanceTyperepo = AssistanceTyperepo;
		}
		
		public async Task<List<GetAssistanceTypeDto>?> GetAssistanceTypesAsync()
		{
			return await _assistanceTyperepo.GetAssistanceTypesAsync();
		}

		public async Task<List<GetAssistanceTypeDto>?> GetAssistanceTypesPageAsync(int page , int pageSize)
		{
			return await _assistanceTyperepo.GetAssistanceTypePage(page , pageSize);
		}

		public async Task AddAssistanceType(AssistanceType assistanceType)
		{
			await _assistanceTyperepo.AddAssistanceTypeAsync(assistanceType);
		}

		public async Task<AssistanceType?> DeleteAssistanceType(int id)
		{

			AssistanceType? temp = await _assistanceTyperepo.GetEntityByIdAsync(id);
			
			if (temp != null) 
			{

				if (temp.Assistances.Count() > 0)
				{
					return new AssistanceType
					{
						AssistanceTypeId = 0,

					};
				}
				await _assistanceTyperepo.DeleteAssistanceTypeAsync(temp);

			}
			
			return temp; 
		}

		public async Task<GetAssistanceTypeDto?> GetAssistanceTyepByIdAsync(int id)
		{
			GetAssistanceTypeDto? temp = await _assistanceTyperepo.GetByIdAsync(id);

			return temp; 
		}

		public async Task UpdateAssistanceTypeAsync(int id, AssistanceType assistanceType)
		{
			AssistanceType? Current = await _assistanceTyperepo.GetEntityByIdAsync(id);
			if (Current != null)
			{
				Current.AssistanceTypeName = assistanceType.AssistanceTypeName;
				Current.AssistanceValue = assistanceType.AssistanceValue;
				Current.IsFinancial = assistanceType.IsFinancial;
				
				await _assistanceTyperepo.UpdateAssistanceTypeAsync(Current);

			}
		}

	}
}
