using Models;
using Models.DTO;

namespace Repository.Interfaces
{
	public interface IMemberGeneralAssemblyRepo : IBasicRepo<MemberGeneralAssembly>
	{
		Task<List<GetGeneralMemberDto>> GetGeneralMembersAsync();
		Task<GetGeneralMemberDto?> GetByIdAsync(string id);
		Task<List<GetGeneralMemberDto>?> GetGeneralMembersPage(int page, int pageSize);
		Task<MemberGeneralAssembly?> GetEntityByIdAsync(string id);
		Task AddGeneralMemberAsync(MemberGeneralAssembly member);
		Task UpdateGeneralMemberAsync(MemberGeneralAssembly member);
		Task DeleteGeneralMemberAsync(MemberGeneralAssembly member);
	}
}
