using Models;
using Models.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepo _personRepo;
		private readonly IFamilyRepo _familyRepo;

		public PersonService(IPersonRepo personRepo , IFamilyRepo familyRepo) 
		{ 
			_personRepo = personRepo;
			_familyRepo = familyRepo;
		}

		public async Task<List<GetPersonDto>?> GetPeopleAsync()
		{
			return await _personRepo.GetPeopleAsync();
		}

		public async Task<List<GetPersonDto>?> GetPeoplePageAsync(int page, int pageSize)
		{
			return await _personRepo.GetPersonPage(page , pageSize);
		}


		public async Task<GetPersonDto?> GetPersonByIdAsync(string id )
		{
			return await _personRepo.GetPersonById(id);
		}

		public async Task AddPersonAsync(Person person)
		{ 
			await _personRepo.AddPersonAsync(person);
		}


		public async Task AddOrphanAsync(AddOrphanDto orphan)
		{
			Person person = new Person
			{
				Id = orphan.Id,
				Gender = orphan.Gender,
				FirstName = orphan.FirstName,
				LastName = orphan.LastName,
				SecondName = orphan.SecondName,
				ThirdName = orphan.ThirdName,
				EducationalLevel = orphan.EducationalLevel,
				GuardianId = orphan.GuardianId,
				FamilyId = orphan.FamilyId,
				Job = orphan.Job,
				PhoneNumber = orphan.PhoneNumber,
				NumberOfFamilyMembers = orphan.NumberOfFamilyMembers,
				IsHouseOwned = orphan.IsHouseOwned,
				IsOrphan = true,
				IsWidow = false,
				IsPartOfFamily = orphan.IsPartOfFamily


			};

			await _personRepo.AddPersonAsync(person);
		}


		public async Task AddWidowAsync(AddWidowDto widow)
		{
			Person person = new Person
			{
				Id = widow.Id,
				Gender = widow.Gender,
				FirstName = widow.FirstName,
				LastName = widow.LastName,
				SecondName = widow.SecondName,
				ThirdName = widow.ThirdName,
				EducationalLevel = widow.EducationalLevel,
				GuardianId = widow.GuardianId,
				FamilyId = widow.FamilyId,
				Job = widow.Job,
				PhoneNumber = widow.PhoneNumber,
				NumberOfFamilyMembers = widow.NumberOfFamilyMembers,
				IsHouseOwned = widow.IsHouseOwned,
				IsOrphan = false,
				IsWidow = true ,
				IsPartOfFamily = widow.IsPartOfFamily


			};

			await _personRepo.AddPersonAsync(person);
		}

		public async Task AddPersonInFamily(AddPersonInFamily personInFamily , int familyId)
		{
			var family = await _familyRepo.GetFamilyByIdAsync(familyId);
			Person person = new Person
			{
				Id = personInFamily.Id,
				Gender = personInFamily.Gender,
				FirstName = personInFamily.FirstName,
				LastName = personInFamily.LastName,
				SecondName = personInFamily.SecondName,
				ThirdName = personInFamily.ThirdName,
				EducationalLevel = personInFamily.EducationalLevel,
				GuardianId = personInFamily.GuardianId,
				
				Job = personInFamily.Job,
				PhoneNumber = personInFamily.PhoneNumber,
				NumberOfFamilyMembers = family!= null ?family.NumberOfFamilyMembers : null,
				IsHouseOwned = family!= null ?family.IsHouseOwned : null ,
				IsOrphan = personInFamily.IsOrphan,
				IsWidow = personInFamily.IsWidow,
				IsPartOfFamily = true,
				FamilyId = family != null ? family.FamilyId : null
			};

			await _personRepo.AddPersonAsync (person);
		}

		public async Task<Person?> DeletePersonAsync(string id)
		{
			Person? deletedPerson= await _personRepo.GetPersonEntityById(id);

			if (deletedPerson!=null)
			{
				if (deletedPerson.Assistances.Count() > 0)
				{
					return new Person
					{
						Id = ""
					};
				}
				else
				{
					await _personRepo.DeletePersonAsync(deletedPerson);
					return deletedPerson;
				}
			}
			return null;
		}

		public async Task<Person?> UpdatePerson(string id , Person UpdatedPerson)
		{
			Person? person = await _personRepo.GetPersonEntityById(id);

			if (person!=null)
			{
				person.PhoneNumber = UpdatedPerson.PhoneNumber;
				person.NumberOfFamilyMembers = UpdatedPerson.NumberOfFamilyMembers;
				person.IsPartOfFamily = UpdatedPerson.IsPartOfFamily;
				person.Gender = UpdatedPerson.Gender;
				person.Job= UpdatedPerson.Job;
				person.EducationalLevel = UpdatedPerson.EducationalLevel;
				person.FirstName = UpdatedPerson.FirstName;
				person.LastName = UpdatedPerson.LastName;
				person.SecondName = UpdatedPerson.SecondName;
				person.ThirdName = UpdatedPerson.ThirdName;
				person.IsWidow = UpdatedPerson.IsWidow;
				person.IsOrphan = UpdatedPerson.IsOrphan;
				person.IsHouseOwned = UpdatedPerson.IsHouseOwned;
				person.Id = UpdatedPerson.Id;
				person.FamilyId = UpdatedPerson.FamilyId;
				person.GuardianId = UpdatedPerson.GuardianId;

				await _personRepo.UpdatePersonAsync(person);
				return person;	
			}
			return person; 
		}
	}
}
