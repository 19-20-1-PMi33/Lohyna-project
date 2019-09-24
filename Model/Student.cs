using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model
{
	public class Student
	{
		public long TicketNumber { get; set; }
		public Person Person { get; set; }
		public long ReportCard { get; set; }
		public Group Group { get; set; }
	}
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
