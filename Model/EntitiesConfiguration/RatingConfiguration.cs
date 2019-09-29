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

			builder.HasOne(x => x.Student)
				.WithMany(y => y.Marks)
				.HasForeignKey(x => x.StudentID);

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Marks)
				.HasForeignKey(x => x.SubjectID);
		}
	}

}
