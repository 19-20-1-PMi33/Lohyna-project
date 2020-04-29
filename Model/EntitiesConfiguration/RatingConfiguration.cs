using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Mark)
				.IsRequired();
			
			builder.Property(x => x.Time)
				.IsRequired();

			builder.HasOne(x => x.Student)
				.WithMany(y => y.Marks)
				.HasForeignKey(x => x.StudentID);

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Marks)
				.HasForeignKey(x => x.SubjectID);
			
			builder.HasData(
                new Rating{Id = 1, Mark = 2, StudentID = 1, SubjectID = "PE", Time = DateTime.Today},
                new Rating{Id = 2, Mark = 20, StudentID = 1, SubjectID = "Math", Time = new DateTime(2020,2,3)},
                new Rating{Id = 3, Mark = 21, Time = new DateTime(2020, 1, 15), SubjectID = "PE", StudentID = 1},
                new Rating{Id = 4, Mark = 4, Time = new DateTime(2003,4,24), SubjectID = "Cryptology", StudentID = 1},
                new Rating{Id = 5, Mark = 5, Time = new DateTime(2004, 12, 23), SubjectID = "Numerical methods", StudentID = 1}
			);
		}
	}

}
