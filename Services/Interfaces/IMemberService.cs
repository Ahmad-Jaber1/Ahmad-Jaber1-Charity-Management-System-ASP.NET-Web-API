using Models;
using Models.DTO;

namespace Services.Interfaces
{
	public interface IMemberService
	{
		Task<List<GetMemberDto>?> GetMembersAsync();
		Task<List<GetMemberDto>?> GetMembersPageAsync(int page, int pageSize);
		Task<GetMemberDto?> GetMemberByIdAsync(string id);
		Task AddMemberAsync(AddMemberDto dto);
		Task<Member?> DeleteMemberAsync(string id);
		Task UpdateMemberAsync(string id, UpdateMemberDto dto);
	}
}
