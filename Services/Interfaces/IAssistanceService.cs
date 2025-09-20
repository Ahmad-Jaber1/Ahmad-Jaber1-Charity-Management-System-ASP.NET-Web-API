using Models;
using Models.DTO;

namespace Services.Interfaces
{
    public interface IAssistanceService
    {

        Task<List<GetAssistanceDto>?> GetAssistancesAsync();

        Task<List<GetAssistanceDto>?> GetAssistancesPageAsync(int page, int pageSize);

		Task<GetAssistanceDto?> GetAssistanceByIdAsync(int id);


        Task AddAssistancAsync(AddAssistanceDTO assistance);


        Task<Assistance?> DeleteAssistanceAsync(int id);



        Task UpdateAssistanceAsync(int id, UpdateAssistanceDto assistance);

    }
}