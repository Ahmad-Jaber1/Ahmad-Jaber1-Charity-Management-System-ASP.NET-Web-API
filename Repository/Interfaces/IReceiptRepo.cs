using Models;
using Models.DTO;

namespace Repository.Interfaces
{
	public interface IReceiptRepo : IBasicRepo<Receipt>
	{
		Task<List<GetReceiptDto>> GetReceiptsAsync();
		Task<GetReceiptDto?> GetByIdAsync(int id);
		Task<List<GetReceiptDto>?> GetReceiptsPage(int page, int pageSize);
		Task<Receipt?> GetEntityByIdAsync(int id);
		Task AddReceiptAsync(Receipt receipt);
		Task UpdateReceiptAsync(Receipt receipt);
		Task DeleteReceiptAsync(Receipt receipt);
	}
}
