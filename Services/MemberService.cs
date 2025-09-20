using Models;
using Models.DTO;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services
{
	public class MemberService : IMemberService
	{
		private readonly IMemberRepo _memberRepo;

		public MemberService(IMemberRepo memberRepo)
		{
			_memberRepo = memberRepo;
		}

		public async Task<List<GetMemberDto>?> GetMembersAsync()
		{
			var result = await _memberRepo.GetMembersAsync();
			return result;
		}

		public async Task<List<GetMemberDto>?> GetMembersPageAsync(int page, int pageSize)
		{
			var result = await _memberRepo.GetMembersPage(page, pageSize);
			return result;
		}

		public async Task<GetMemberDto?> GetMemberByIdAsync(string id)
		{
			return await _memberRepo.GetByIdAsync(id);
		}

		public async Task AddMemberAsync(AddMemberDto dto)
		{
			var member = new Member
			{
				Id = dto.Id,
				FirstName = dto.FirstName,
				SecondName = dto.SecondName,
				LastName = dto.LastName,
				Location = dto.Location,
				PhoneNumber = dto.PhoneNumber,
				IsMembershipPaid = dto.IsMembershipPaid,
				ReceiptId = dto.ReceiptNO
			};

			await _memberRepo.AddMemberAsync(member);
		}

		public async Task<Member?> DeleteMemberAsync(string id)
		{
			var member = await _memberRepo.GetEntityByIdAsync(id);
			if (member != null)
			{
				if (member.Receipt != null)
				{
					return new Member
					{
						Id = "0" 
					};
				}

				await _memberRepo.DeleteMemberAsync(member);
			}
			return member;
		}


		public async Task UpdateMemberAsync(string id, UpdateMemberDto dto)
		{
			var current = await _memberRepo.GetEntityByIdAsync(id);
			if (current != null)
			{
				current.FirstName = dto.FirstName;
				current.SecondName = dto.SecondName;
				current.LastName = dto.LastName;
				current.Location = dto.Location;
				current.PhoneNumber = dto.PhoneNumber;
				current.IsMembershipPaid = dto.IsMembershipPaid;
				current.ReceiptId = dto.ReceiptNO;

				await _memberRepo.UpdateMemberAsync(current);
			}
		}
	}
}
