using Models;
using Models.DTO;

namespace Repository.Interfaces
{
    public interface IAssistanceRepo
    {

		  Task<List<GetAssistanceDto>> GetAssistanceAsync();

		Task<GetAssistanceDto?> GetByIdAsync(int id);


		Task AddAssistanceAsync(Assistance assistance);


		Task DeleteAssistanceAsync(Assistance assistance);


		Task UpdateAssistanceAsync(Assistance assistance);

		Task<Assistance?> GetEntityByIdAsync(int id);

		Task<List<GetAssistanceDto>?> GetAssistancesPage(int page, int pageSize);


	}
}