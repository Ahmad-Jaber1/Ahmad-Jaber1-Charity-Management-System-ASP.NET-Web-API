using Microsoft.AspNetCore.Http;
using Models.DTO;

namespace Services.Interfaces
{
    public interface IUploadFilesService
    {

		public Task UpoladFileForYear(int year, IFormFile file);

		public Task<FileResultModel?> GetFile(int year);



	}
}