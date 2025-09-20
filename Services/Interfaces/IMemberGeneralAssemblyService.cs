using Models;
using Models.DTO;

namespace Services.Interfaces
{
	public interface IMemberGeneralAssemblyService
	{
		Task<List<GetGeneralMemberDto>?> GetGeneralMembersAsync();
		Task<List<GetGeneralMemberDto>?> GetGeneralMembersPageAsync(int page, int pageSize);
		Task<GetGeneralMemberDto?> GetGeneralMemberByIdAsync(string id);
		Task AddGeneralMemberAsync(AddGeneralMemberDto dto);
		Task<MemberGeneralAssembly?> DeleteGeneralMemberAsync(string id);
		Task UpdateGeneralMemberAsync(string id, UpdateGeneralMemberDto dto);
	}
}
