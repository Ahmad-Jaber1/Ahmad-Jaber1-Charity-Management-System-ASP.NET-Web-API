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
	public class MemberConfig : IEntityTypeConfiguration<Member>
	{
		public void Configure(EntityTypeBuilder<Member> builder)
		{
			builder.HasOne(x => x.Receipt).WithOne(y => y.Member)
				.HasForeignKey<Member>(z => z.ReceiptId )
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
