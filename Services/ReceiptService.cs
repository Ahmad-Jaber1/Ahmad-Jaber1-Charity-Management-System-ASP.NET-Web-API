using Models;
using Models.DTO;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
	public class ReceiptService : IReceiptService
	{
		private readonly IReceiptRepo _receiptRepo;

		public ReceiptService(IReceiptRepo receiptRepo)
		{
			_receiptRepo = receiptRepo;
		}

		public async Task<List<GetReceiptDto>?> GetReceiptsAsync()
		{
			return await _receiptRepo.GetReceiptsAsync();
		}

		public async Task<List<GetReceiptDto>?> GetReceiptsPageAsync(int page, int pageSize)
		{
			return await _receiptRepo.GetReceiptsPage(page, pageSize);
		}

		public async Task<GetReceiptDto?> GetReceiptByIdAsync(int id)
		{
			return await _receiptRepo.GetByIdAsync(id);
		}

		public async Task AddReceiptAsync(AddReceiptDto dto)
		{
			var receipt = new Receipt
			{
				ReceiptNO = dto.ReceiptNO,
				Value = dto.Value,
				Year = dto.Year,
				Month = dto.Month,
				PaidDate = dto.PaidDate,
				BasicMemberId = dto.BasicMemberId
			};

			await _receiptRepo.AddReceiptAsync(receipt);
		}

		public async Task<Receipt?> DeleteReceiptAsync(int id)
		{
			var receipt = await _receiptRepo.GetEntityByIdAsync(id);
			if (receipt != null)
			{
				await _receiptRepo.DeleteReceiptAsync(receipt);
			}
			return receipt;
		}

		public async Task UpdateReceiptAsync(int id, UpdateReceiptDto dto)
		{
			var receipt = await _receiptRepo.GetEntityByIdAsync(id);
			if (receipt != null)
			{
				receipt.Value = dto.Value;
				receipt.Year = dto.Year;
				receipt.Month = dto.Month;
				receipt.PaidDate = dto.PaidDate;
				receipt.BasicMemberId = dto.BasicMemberId;

				await _receiptRepo.UpdateReceiptAsync(receipt);
			}
		}
	}
}
