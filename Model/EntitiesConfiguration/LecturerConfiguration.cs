using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
	{
		public void Configure(EntityTypeBuilder<Lecturer> builder)
		{
			builder.HasKey(x => x.ID);

			builder.Property(x => x.Department)
				.IsRequired();

			// builder.HasOne(x => x.Person)
			// 	.WithOne(y => y.Lecturer)
			// 	.HasForeignKey(x => x.PersonID);

			builder.HasMany(x => x.Lessons)
				.WithOne(y => y.Lecturer)
				.HasForeignKey(y => y.LecturerID);

			builder.HasMany(x => x.Specializations)
				.WithOne(y => y.Lecturer)
				.HasForeignKey(y => y.LecturerID);
			builder.HasData(new Lecturer{ID=1,Department="Mechanical mathematics",PersonID="iryna007"},
			new Lecturer{ID=2,Department="Applied Mathematics",PersonID="halamaha"});
		}
	}
}
