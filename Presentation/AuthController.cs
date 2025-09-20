using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{

	[Route("api/[controller]")]
	[ApiController]

	public class AuthController : ControllerBase
	{
		private readonly IAuthService _auth;

		public AuthController(IAuthService auth)
		{
			_auth = auth;
		}
		[HttpPost("Register")]
		[Authorize(Roles = "Admin")]

		public async Task<IActionResult> Register(UserRegister user)
		{

            if (await _auth.Register(user))
            {
				return Ok("Successfully Register");
            }

            return BadRequest("There is Problem !");
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login(UserLogin user)
		{
			string token;
			if (await _auth.Login(user))
			{
				token = await _auth.GenerateToken(user);
				return Ok(token);
			}

			return BadRequest("Username or Passward is Wrong!");
		}
	}
}
