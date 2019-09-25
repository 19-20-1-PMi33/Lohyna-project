using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(x => x.TicketNumber);
			builder.Property(x => x.Person).IsRequired();
			builder.Property(x => x.ReportCard).IsRequired();
			builder.Property(x => x.Group).IsRequired();
		}
	}
}
