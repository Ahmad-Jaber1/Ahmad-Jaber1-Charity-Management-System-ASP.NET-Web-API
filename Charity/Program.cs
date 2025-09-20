using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Repository.Interfaces;
using Services;
using Presentation;
using Services.Interfaces;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Charity
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();

			builder.Services.AddDbContext<CharityDbContex>(option =>
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Dependency Injection
			builder.Services.AddScoped<IAssistanceTypeService, AssistanceTypeService>();
			builder.Services.AddScoped<IAssistanceTypeRepo, AssistanceTypeRepo>();

			builder.Services.AddScoped<IAssistanceService, AssistanceService>();
			builder.Services.AddScoped<IAssistanceRepo, AssistanceRepo>();

			builder.Services.AddScoped<IPersonRepo, PersonRepo>();
			builder.Services.AddScoped<IPersonService, PersonService>();

			builder.Services.AddScoped<IFamilyRepo, FamilyRepo>();
			builder.Services.AddScoped<IFamilyService, FamilyService>();

			builder.Services.AddScoped<IGuardianRepo, GuardianRepo>();
			builder.Services.AddScoped<IGuardianService, GuardianService>();

			builder.Services.AddScoped<IMemberRepo, MemberRepo>();
			builder.Services.AddScoped<IMemberService, MemberService>();

			builder.Services.AddScoped<IMemberGeneralAssemblyRepo, MemberGeneralAssemblyRepo>();
			builder.Services.AddScoped<IMemberGeneralAssemblyService, MemberGeneralAssemblyService>();

			builder.Services.AddScoped<IReceiptRepo, ReceiptRepo>();
			builder.Services.AddScoped<IReceiptService, ReceiptService>();

			builder.Services.AddScoped<IUploadFilesService, UploadFilesService>();
			builder.Services.AddScoped<IAuthService, AuthService>();

			// JSON Serialization Options
			builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			// Identity configuration
			builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 3;
			})
			.AddEntityFrameworkStores<CharityDbContex>()
			.AddDefaultTokenProviders();

			// JWT Authentication
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateActor = true,
					ValidateAudience = true,
					ValidateIssuer = true,
					RequireExpirationTime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["jwt:Issuer"],
					ValidAudience = builder.Configuration["jwt:Audience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))
				};
			});

			// CORS configuration
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowFrontend", policy =>
				{
					// ?? For production, restrict to specific origins
					policy
						//.WithOrigins("http://localhost:8080", "https://alkawkab-charity.netlify.app")
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			// Swagger (API Docs)
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// CORS should be used before authentication
			app.UseCors("AllowFrontend");

			if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			// HTTP request pipeline
			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
