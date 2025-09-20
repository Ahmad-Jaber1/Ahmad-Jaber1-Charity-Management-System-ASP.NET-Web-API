using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Repository.Interfaces;

namespace Repository
{
	public class MemberRepo : BasicRepo<Member>, IMemberRepo
	{
		public MemberRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}

		public async Task<List<GetMemberDto>> GetMembersAsync()
		{
			return await GetAll()
				.Select(x => new GetMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsMembershipPaid = x.IsMembershipPaid,
					ReceiptNO = x.ReceiptId
				}).ToListAsync();
		}

		public async Task<GetMemberDto?> GetByIdAsync(string id)
		{
			return await GetAll()
				.Select(x => new GetMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsMembershipPaid = x.IsMembershipPaid,
					ReceiptNO = x.ReceiptId
				}).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<GetMemberDto>?> GetMembersPage(int page, int pageSize)
		{
			return await GetAll()
				.Select(x => new GetMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsMembershipPaid = x.IsMembershipPaid,
					ReceiptNO = x.ReceiptId
				})
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<Member?> GetEntityByIdAsync(string id)
		{
			return await GetAll().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task AddMemberAsync(Member member)
		{
			Add(member);
			await SaveChangeAsync();
		}

		public async Task UpdateMemberAsync(Member member)
		{
			Update(member);
			await SaveChangeAsync();
		}

		public async Task DeleteMemberAsync(Member member)
		{
			Delete(member);
			await SaveChangeAsync();
		}
	}
}
