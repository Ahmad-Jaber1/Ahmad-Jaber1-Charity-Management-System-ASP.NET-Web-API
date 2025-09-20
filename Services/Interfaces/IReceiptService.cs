using Models;
using Models.DTO;

namespace Services.Interfaces
{
	public interface IReceiptService
	{
		Task<List<GetReceiptDto>?> GetReceiptsAsync();
		Task<List<GetReceiptDto>?> GetReceiptsPageAsync(int page, int pageSize);
		Task<GetReceiptDto?> GetReceiptByIdAsync(int id);
		Task AddReceiptAsync(AddReceiptDto dto);
		Task<Receipt?> DeleteReceiptAsync(int id);
		Task UpdateReceiptAsync(int id, UpdateReceiptDto dto);
	}
}
