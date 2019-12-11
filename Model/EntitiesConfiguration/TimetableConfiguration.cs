using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
	{
		public void Configure(EntityTypeBuilder<Timetable> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Day)
				.IsRequired();

			builder.Property(x => x.Period);

			builder.HasOne(x => x.Time)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.TimeID);

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.SubjectID);

			builder.HasOne(x => x.Group)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.GroupID);

			builder.HasOne(x => x.Lecturer)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.LecturerID);
		}
	}
}
