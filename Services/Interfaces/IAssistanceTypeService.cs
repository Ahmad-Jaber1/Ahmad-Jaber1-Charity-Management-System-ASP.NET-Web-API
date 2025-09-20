using Models;
using Models.DTO;

namespace Services.Interfaces
{
    public interface IAssistanceTypeService
    {

        Task<List<GetAssistanceTypeDto>?> GetAssistanceTypesAsync();


        Task AddAssistanceType(AssistanceType assistanceType);


        Task<AssistanceType?> DeleteAssistanceType(int id);


        Task<GetAssistanceTypeDto?> GetAssistanceTyepByIdAsync(int id);


        Task UpdateAssistanceTypeAsync(int id, AssistanceType assistanceType);
        Task<List<GetAssistanceTypeDto>?> GetAssistanceTypesPageAsync(int page, int pageSize);


	}
}