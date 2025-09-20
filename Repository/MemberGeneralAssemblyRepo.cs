using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using Repository.Interfaces;

namespace Repository
{
	public class MemberGeneralAssemblyRepo : BasicRepo<MemberGeneralAssembly>, IMemberGeneralAssemblyRepo
	{
		public MemberGeneralAssemblyRepo(CharityDbContex dbContext) : base(dbContext)
		{
		}

		public async Task<List<GetGeneralMemberDto>> GetGeneralMembersAsync()
		{
			return await GetAll()
				.Select(x => new GetGeneralMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsAdministrativeMember = x.IsAdministrativeMember,
					AdministrativePosition = x.AdministrativePosition,
					Receipts = x.Receipts.Select(r => r.ReceiptNO).ToList()
				}).ToListAsync();
		}

		public async Task<GetGeneralMemberDto?> GetByIdAsync(string id)
		{
			return await GetAll()
				.Select(x => new GetGeneralMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsAdministrativeMember = x.IsAdministrativeMember,
					AdministrativePosition = x.AdministrativePosition,
					Receipts = x.Receipts.Select(r => r.ReceiptNO).ToList()
				}).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<GetGeneralMemberDto>?> GetGeneralMembersPage(int page, int pageSize)
		{
			return await GetAll()
				.Select(x => new GetGeneralMemberDto
				{
					Id = x.Id,
					FirstName = x.FirstName,
					SecondName = x.SecondName,
					LastName = x.LastName,
					Location = x.Location,
					PhoneNumber = x.PhoneNumber,
					IsAdministrativeMember = x.IsAdministrativeMember,
					AdministrativePosition = x.AdministrativePosition,
					Receipts = x.Receipts.Select(r => r.ReceiptNO).ToList()
				})
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToListAsync();
		}

		public async Task<MemberGeneralAssembly?> GetEntityByIdAsync(string id)
		{
			return await GetAll().Include(x => x.Receipts).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task AddGeneralMemberAsync(MemberGeneralAssembly member)
		{
			Add(member);
			await SaveChangeAsync();
		}

		public async Task UpdateGeneralMemberAsync(MemberGeneralAssembly member)
		{
			Update(member);
			await SaveChangeAsync();
		}

		public async Task DeleteGeneralMemberAsync(MemberGeneralAssembly member)
		{
			Delete(member);
			await SaveChangeAsync();
		}
	}
}
