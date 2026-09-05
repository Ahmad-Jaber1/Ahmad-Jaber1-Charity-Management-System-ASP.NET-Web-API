using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			try
			{
				var receipts = await _receiptService.GetReceiptsAsync();
				return Ok(receipts ?? new List<GetReceiptDto>());
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء جلب بيانات الإيصالات." });
			}
		}

		[HttpGet("GetPage")]
		public async Task<IActionResult> GetReceiptsPage(int page = 1, int pageSize = 10)
		{
			try
			{
				var receipts = await _receiptService.GetReceiptsPageAsync(page, pageSize);
				return Ok(receipts ?? new List<GetReceiptDto>());
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء جلب صفحة الإيصالات." });
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetReceiptById(int id)
		{
			try
			{
				var receipt = await _receiptService.GetReceiptByIdAsync(id);
				if (receipt != null)
					return Ok(receipt);
				return NotFound(new { message = "الإيصال غير موجود" });
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء جلب بيانات الإيصال." });
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddReceipt(AddReceiptDto dto)
		{
			try
			{
				if (dto == null)
				{
					return BadRequest(new { message = "بيانات الإيصال غير صالحة" });
				}

				if (dto.Value <= 0)
				{
					return BadRequest(new { message = "قيمة الإيصال يجب أن تكون أكبر من صفر" });
				}

				if (dto.Year < 1900 || dto.Year > 2100)
				{
					return BadRequest(new { message = "يرجى إدخال سنة صحيحة" });
				}

				if (dto.Month < 1 || dto.Month > 12)
				{
					return BadRequest(new { message = "يرجى اختيار شهر صحيح" });
				}

				if (dto.ReceiptNO > 0)
				{
					var existing = await _receiptService.GetReceiptByIdAsync(dto.ReceiptNO);
					if (existing != null)
					{
						return BadRequest(new { message = "رقم الإيصال مسجل مسبقاً، يرجى اختيار رقم آخر" });
					}
				}

				await _receiptService.AddReceiptAsync(dto);
				return Ok(new { message = "تم إضافة الإيصال بنجاح" });
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء إضافة الإيصال. يرجى التحقق من صحة البيانات." });
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateReceipt(int id, UpdateReceiptDto dto)
		{
			try
			{
				var existing = await _receiptService.GetReceiptByIdAsync(id);
				if (existing == null)
				{
					return NotFound(new { message = "الإيصال غير موجود" });
				}

				if (dto.Value <= 0)
				{
					return BadRequest(new { message = "قيمة الإيصال يجب أن تكون أكبر من صفر" });
				}

				if (dto.Year < 1900 || dto.Year > 2100)
				{
					return BadRequest(new { message = "يرجى إدخال سنة صحيحة" });
				}

				if (dto.Month < 1 || dto.Month > 12)
				{
					return BadRequest(new { message = "يرجى اختيار شهر صحيح" });
				}

				await _receiptService.UpdateReceiptAsync(id, dto);
				return Ok(new { message = "تم تحديث بيانات الإيصال بنجاح" });
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء تحديث بيانات الإيصال. يرجى التحقق من صحة البيانات." });
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteReceipt(int id)
		{
			try
			{
				var existing = await _receiptService.GetReceiptByIdAsync(id);
				if (existing == null)
				{
					return NotFound(new { message = "الإيصال غير موجود" });
				}

				var receipt = await _receiptService.DeleteReceiptAsync(id);
				if (receipt != null)
					return Ok(new { message = "تم حذف الإيصال بنجاح" });
				return NotFound(new { message = "الإيصال غير موجود" });
			}
			catch (DbUpdateException)
			{
				return BadRequest(new { message = "لا يمكن حذف هذا الإيصال لأنه مرتبط بعضو مسجل" });
			}
			catch (Exception)
			{
				return StatusCode(500, new { message = "حدث خطأ أثناء حذف الإيصال." });
			}
		}
	}
}
