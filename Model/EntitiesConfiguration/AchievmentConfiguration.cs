using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class AchievmentConfiguration : IEntityTypeConfiguration<Achievment>
	{
		public void Configure(EntityTypeBuilder<Achievment> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Text)
				.IsRequired();
            
            builder.Property(x=>x.Photo);
			
			builder.Property(x => x.Time)
				.IsRequired();

			builder.HasOne(x => x.Student)
				.WithMany(y => y.Achievments)
				.HasForeignKey(x => x.StudentID);
            
            builder.HasData(new Achievment{Id = 1,Text="Second best starosta in group!",Photo="DbResources/Ach/ach1.png",Time = System.DateTime.Now,StudentID=11111111},
            new Achievment{Id = 2,Text="The bluest lohyna in team!",Photo="DbResources/Ach/ach2.png",Time = System.DateTime.Now,StudentID=33333333},
            new Achievment{Id = 3,Text="The man who bought the world!",Photo="DbResources/Ach/ach3.png",Time = System.DateTime.Now,StudentID=22222222},
            new Achievment{Id = 4,Text="Passed PE exam without praying!",Photo="DbResources/Ach/ach4.png",Time = System.DateTime.Now,StudentID=44444444});
		}
	}

}
