using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
	public interface IPersonRepo
	{
		Task<List<GetPersonDto>> GetPeopleAsync();


		 Task<GetPersonDto?> GetPersonById(string id);

		Task<Person?> GetPersonEntityById(string id);
		Task AddPersonAsync(Person person);


		 Task UpdatePersonAsync(Person person);

		 Task DeletePersonAsync(Person person);

		Task<List<GetPersonDto>?> GetPersonPage(int page, int pageSize);


	}
}
