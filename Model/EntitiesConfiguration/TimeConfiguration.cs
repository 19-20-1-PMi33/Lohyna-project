using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Model.EntitiesConfiguration
{
	public class TimeConfiguration : IEntityTypeConfiguration<Time>
	{
		public void Configure(EntityTypeBuilder<Time> builder)
		{
			builder.HasKey(x => x.Number);

			builder.Property(x => x.Start)
				.IsRequired();

			builder.Property(x => x.Finish)
				.IsRequired();

			builder.HasMany(x => x.Lessons)
				.WithOne(y => y.Time)
				.HasForeignKey(y => y.TimeID);
			builder.HasData(
				new Time{Number=1,Start=new DateTime(2020,1,1,8,30,0),Finish = new DateTime(2020,8,30,9,50,0)},
				new Time{Number=2,Start=new DateTime(2020,1,1,10,10,0),Finish = new DateTime(2020,8,30,11,30,0)},
				new Time{Number=3,Start=new DateTime(2020,1,1,11,50,0),Finish = new DateTime(2020,8,30,13,10,0)},
				new Time{Number=4,Start=new DateTime(2020,1,1,13,30,0),Finish = new DateTime(2020,8,30,14,50,0)},
				new Time{Number=5,Start=new DateTime(2020,1,1,15,05,0),Finish = new DateTime(2020,8,30,16,25,0)},
				new Time{Number=6,Start=new DateTime(2020,1,1,16,40,0),Finish = new DateTime(2020,8,30,18,0,0)},
				new Time{Number=7,Start=new DateTime(2020,1,1,18,10,0),Finish = new DateTime(2020,8,30,19,30,0)}
			);
		}
	}
}
