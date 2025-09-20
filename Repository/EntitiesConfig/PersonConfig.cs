using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntitiesConfig
{
	public class PersonConfig : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Guardian).WithMany(y => y.PeopleUnderGuardianship)
				.HasForeignKey(z => z.GuardianId)
				.OnDelete(DeleteBehavior.SetNull);

			builder.HasOne(x => x.Family).WithMany(y => y.FamilyMembers)
				.HasForeignKey(z => z.FamilyId)
				.OnDelete(DeleteBehavior.Cascade);

			

		}
	}
}
