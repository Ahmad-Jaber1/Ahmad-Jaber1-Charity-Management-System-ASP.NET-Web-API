using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
	public interface IAuthService
	{
		Task<string> GenerateToken(UserLogin user);

		Task<bool> Login(UserLogin user);
		public Task<bool> Register(UserRegister user);

	}
}
