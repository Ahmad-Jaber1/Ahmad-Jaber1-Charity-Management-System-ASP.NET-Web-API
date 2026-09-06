using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Repository.Interfaces;

namespace Repository
{
	public class ReceiptRepo : BasicRepo<Receipt>, IReceiptRepo
	{
		private readonly CharityDbContex _dbContext;

		public ReceiptRepo(CharityDbContex dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<GetReceiptDto>> GetReceiptsAsync()
		{
			return await GetAll()
				.Select(x => new GetReceiptDto
				{
					ReceiptNO = x.ReceiptNO,
					Value = x.Value,
					Year = x.Year,
					Month = x.Month,
					PaidDate = x.PaidDate,
					BasicMemberId = x.BasicMemberId
				}).ToListAsync();
		}

		public async Task<GetReceiptDto?> GetByIdAsync(int id)
		{
			return await GetAll()
				.Select(x => new GetReceiptDto
				{
					ReceiptNO = x.ReceiptNO,
					Value = x.Value,
					Year = x.Year,
					Month = x.Month,
					PaidDate = x.PaidDate,
					BasicMemberId = x.BasicMemberId
				}).FirstOrDefaultAsync(x => x.ReceiptNO == id);
		}

		public async Task<List<GetReceiptDto>?> GetReceiptsPage(int page, int pageSize)
		{
			return await GetAll()
				.Select(x => new GetReceiptDto
				{
					ReceiptNO = x.ReceiptNO,
					Value = x.Value,
					Year = x.Year,
					Month = x.Month,
					PaidDate = x.PaidDate,
					BasicMemberId = x.BasicMemberId
				})
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<Receipt?> GetEntityByIdAsync(int id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.ReceiptNO == id);
		}

		public async Task AddReceiptAsync(Receipt receipt)
		{
			if (receipt.ReceiptNO > 0)
			{
				using var transaction = await _dbContext.Database.BeginTransactionAsync();
				try
				{
					await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Receipts ON;");
					Add(receipt);
					await SaveChangeAsync();
					await _dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Receipts OFF;");
					await transaction.CommitAsync();
				}
				catch
				{
					await transaction.RollbackAsync();
					throw;
				}
			}
			else
			{
				Add(receipt);
				await SaveChangeAsync();
			}
		}

		public async Task UpdateReceiptAsync(Receipt receipt)
		{
			Update(receipt);
			await SaveChangeAsync();
		}

		public async Task DeleteReceiptAsync(Receipt receipt)
		{
			Delete(receipt);
			await SaveChangeAsync();
		}
	}
}
