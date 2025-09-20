using Models;
using Models.DTO;

namespace Repository.Interfaces
{
	public interface IMemberRepo : IBasicRepo<Member>
	{
		Task<List<GetMemberDto>> GetMembersAsync();
		Task<GetMemberDto?> GetByIdAsync(string id);
		Task<List<GetMemberDto>?> GetMembersPage(int page, int pageSize);
		Task<Member?> GetEntityByIdAsync(string id);
		Task AddMemberAsync(Member member);
		Task UpdateMemberAsync(Member member);
		Task DeleteMemberAsync(Member member);
	}
}
