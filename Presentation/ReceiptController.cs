using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Services.Interfaces;

namespace Presentation
{
	[ApiController]
	[Route("api/[controller]")]

	[Authorize(Roles = "Admin,Supervisor")]

	public class ReceiptController : ControllerBase
	{
		private readonly IReceiptService _receiptService;

		public ReceiptController(IReceiptService receiptService)
		{
			_receiptService = receiptService;
		}

		[HttpGet]
		public async Task<IActionResult> GetReceipts()
		{
			var receipts = await _receiptService.GetReceiptsAsync();
			return Ok(receipts);
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetReceiptsPage(int page = 1, int pageSize = 10)
		{
			var receipts = await _receiptService.GetReceiptsPageAsync(page, pageSize);
			return Ok(receipts);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetReceiptById(int id)
		{
			var receipt = await _receiptService.GetReceiptByIdAsync(id);
			if (receipt != null)
				return Ok(receipt);
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddReceipt(AddReceiptDto dto)
		{
			await _receiptService.AddReceiptAsync(dto);
			return Ok();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateReceipt(int id, UpdateReceiptDto dto)
		{
			await _receiptService.UpdateReceiptAsync(id, dto);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReceipt(int id)
		{
			var receipt = await _receiptService.DeleteReceiptAsync(id);
			if (receipt != null)
				return Ok(receipt);
			return NotFound();
		}
	}
}
