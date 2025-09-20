using Models;
using Models.DTO;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
	public class MemberGeneralAssemblyService : IMemberGeneralAssemblyService
	{
		private readonly IMemberGeneralAssemblyRepo _generalRepo;

		public MemberGeneralAssemblyService(IMemberGeneralAssemblyRepo generalRepo)
		{
			_generalRepo = generalRepo;
		}

		public async Task<List<GetGeneralMemberDto>?> GetGeneralMembersAsync()
		{
			return await _generalRepo.GetGeneralMembersAsync();
		}

		public async Task<List<GetGeneralMemberDto>?> GetGeneralMembersPageAsync(int page, int pageSize)
		{
			return await _generalRepo.GetGeneralMembersPage(page, pageSize);
		}

		public async Task<GetGeneralMemberDto?> GetGeneralMemberByIdAsync(string id)
		{
			return await _generalRepo.GetByIdAsync(id);
		}

		public async Task AddGeneralMemberAsync(AddGeneralMemberDto dto)
		{
			var member = new MemberGeneralAssembly
			{
				Id = dto.Id,
				FirstName = dto.FirstName,
				SecondName = dto.SecondName,
				LastName = dto.LastName,
				Location = dto.Location,
				PhoneNumber = dto.PhoneNumber,
				IsAdministrativeMember = dto.IsAdministrativeMember,
				AdministrativePosition = dto.AdministrativePosition
			};

			await _generalRepo.AddGeneralMemberAsync(member);
		}

		public async Task<MemberGeneralAssembly?> DeleteGeneralMemberAsync(string id)
		{
			var member = await _generalRepo.GetEntityByIdAsync(id);
			if (member != null)
			{
				
				if (member.Receipts.Any())
				{
					return new MemberGeneralAssembly
					{
						Id = "0" 
					};
				}

				await _generalRepo.DeleteGeneralMemberAsync(member);
			}
			return member;
		}


		public async Task UpdateGeneralMemberAsync(string id, UpdateGeneralMemberDto dto)
		{
			var member = await _generalRepo.GetEntityByIdAsync(id);
			if (member != null)
			{
				member.FirstName = dto.FirstName;
				member.SecondName = dto.SecondName;
				member.LastName = dto.LastName;
				member.Location = dto.Location;
				member.PhoneNumber = dto.PhoneNumber;
				member.IsAdministrativeMember = dto.IsAdministrativeMember;
				member.AdministrativePosition = dto.AdministrativePosition;

				await _generalRepo.UpdateGeneralMemberAsync(member);
			}
		}
	}
}
