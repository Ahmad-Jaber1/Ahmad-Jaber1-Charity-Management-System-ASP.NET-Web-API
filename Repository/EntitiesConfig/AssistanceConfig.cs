using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Repository.EntitiesConfig
{
	public class AssistanceConfig : IEntityTypeConfiguration<Assistance>
	{
		public void Configure(EntityTypeBuilder<Assistance> builder)
		{
			builder.HasKey(x => x.AssistanceId);

			builder.HasOne(x => x.AssistanceType).WithMany(y => y.Assistances)
				.HasForeignKey(z=>z.AssistanceTypeId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Person).WithMany(y => y.Assistances)
				.HasForeignKey(z => z.PersonId) .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Family).WithMany(y => y.Assistances)
				.HasForeignKey(z => z.FamilyId).OnDelete(DeleteBehavior.Restrict);

			builder.Property(x => x.AssistanceId).ValueGeneratedOnAdd();


		}
	}
}
