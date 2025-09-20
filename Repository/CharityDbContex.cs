using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.EntitiesConfig;



namespace Repository
{
	public class CharityDbContex : IdentityDbContext
	{
		public DbSet<Assistance> Assistances { get; set; }
		public DbSet<AssistanceType> AssistanceTypes { get; set; }
		public DbSet<Family> Families { get; set; }
		public DbSet<Person> People { get; set; }

		public DbSet<Guardian> Guardians { get; set; }

		public DbSet<Member> Members { get; set; }
		public DbSet<MemberGeneralAssembly> MembersGeneralAssembly { get; set; }
		public DbSet<Receipt> Receipts { get; set; }

		public CharityDbContex(DbContextOptions<CharityDbContex> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new AssistanceConfig());
			modelBuilder.ApplyConfiguration(new PersonConfig());

			modelBuilder.Entity<AssistanceType>().Property(x => x.AssistanceTypeId)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Family>().Property(x => x.FamilyId)
				.ValueGeneratedOnAdd();

			

		}

	}
}
