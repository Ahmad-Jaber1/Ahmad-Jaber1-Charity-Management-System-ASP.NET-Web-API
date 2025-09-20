using Models.DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
	public interface IPersonService
	{

		public  Task<List<GetPersonDto>?> GetPeopleAsync();

		Task<List<GetPersonDto>?> GetPeoplePageAsync(int page, int pageSize);

		public Task<GetPersonDto?> GetPersonByIdAsync(string id);


		public  Task AddPersonAsync(Person person);




		public Task AddOrphanAsync(AddOrphanDto orphan);




		public Task AddWidowAsync(AddWidowDto widow);



		public Task AddPersonInFamily(AddPersonInFamily personInFamily, int familyId);



		public Task<Person?> DeletePersonAsync(string id);



		public Task<Person?> UpdatePerson(string id, Person UpdatedPerson);
		
	}
}
