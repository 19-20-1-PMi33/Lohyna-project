using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
				new Rating {Id = 1, Mark = 4 , Time = new DateTime(2020, 2, 10, 12, 25, 40),  SubjectID = "Android" , StudentID = 11111111},
				new Rating {Id = 2, Mark = 2 , Time = new DateTime(2009, 2, 10, 12, 13, 43),  SubjectID = "Cryptology" , StudentID = 11111111},
				new Rating {Id = 3, Mark = 1 , Time = new DateTime(2020, 2, 10, 12, 45, 40),  SubjectID = "Cryptology" , StudentID = 11111111},
				new Rating {Id = 4, Mark = 22 , Time = new DateTime(2019, 2, 10, 12, 23, 10),  SubjectID = "NodeJS" , StudentID = 11111111},
				new Rating {Id = 5, Mark = 16, Time = new DateTime(2020, 3, 10, 12, 23, 20),  SubjectID = "Android" , StudentID = 11111111},
				new Rating {Id = 6, Mark = 12 , Time = new DateTime(2020, 2, 11, 12, 23, 40),  SubjectID = "Computer methods" , StudentID = 11111111},
				new Rating {Id = 7, Mark = 6 , Time = new DateTime(2020, 3, 10, 12, 23, 40),  SubjectID = "PE" , StudentID = 11111111},
				new Rating {Id = 8, Mark = 5 , Time = new DateTime(2020, 1, 10, 16, 23, 40),  SubjectID = "PE" , StudentID = 11111111}
				);
		}
	}

}
