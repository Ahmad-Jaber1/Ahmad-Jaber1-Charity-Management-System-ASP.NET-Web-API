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
	public class MemberGeneralAssemblyConfig : IEntityTypeConfiguration<MemberGeneralAssembly>
	{
		public void Configure(EntityTypeBuilder<MemberGeneralAssembly> builder)
		{
			builder.HasMany(x=>x.Receipts).WithOne(y=>y.MemberGeneralAssembly)
				.HasForeignKey(x=>x.BasicMemberId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
