using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _config;

		public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_config = config;
		}

		public async Task<bool> Register(UserRegister user)
		{
			// Validate role
			if (user.Role != "Admin" && user.Role != "Supervisor")
				return false;

			// Ensure roles exist (one-time setup, safe to call every time)
			if (!await _roleManager.RoleExistsAsync("Admin"))
				await _roleManager.CreateAsync(new IdentityRole("Admin"));

			if (!await _roleManager.RoleExistsAsync("Supervisor"))
				await _roleManager.CreateAsync(new IdentityRole("Supervisor"));

			var identityUser = new IdentityUser
			{
				UserName = user.UserName,
				Email = user.UserName
			};

			var result = await _userManager.CreateAsync(identityUser, user.Password);
			if (!result.Succeeded)
				return false;

			// Assign role
			await _userManager.AddToRoleAsync(identityUser, user.Role);

			return true;
		}

		public async Task<bool> Login(UserLogin user)
		{
			var identityUser = await _userManager.FindByEmailAsync(user.UserName);
			if (identityUser == null)
				return false;

			return await _userManager.CheckPasswordAsync(identityUser, user.Password);
		}

		public async Task<string> GenerateToken(UserLogin user)
		{
			var identityUser = await _userManager.FindByEmailAsync(user.UserName);
			if (identityUser == null)
				return null;

			var roles = await _userManager.GetRolesAsync(identityUser);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.UserName),
				new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
			};

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			string key = _config.GetSection("jwt:key").Value;
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
			var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var securityToken = new JwtSecurityToken(
				issuer: _config["jwt:Issuer"],
				audience: _config["jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: signingCred
			);

			return new JwtSecurityTokenHandler().WriteToken(securityToken);
		}
	}
}
