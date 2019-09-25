using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
	{
		public void Configure(EntityTypeBuilder<Timetable> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Subject).IsRequired();
			builder.Property(x => x.Time).IsRequired();
			builder.Property(x => x.Day).IsRequired();
			builder.Property(x => x.Period).IsRequired();
			builder.Property(x => x.Group).IsRequired();
			builder.Property(x => x.Lecturer).IsRequired();
		}
	}
}
