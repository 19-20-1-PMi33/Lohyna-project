using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model
{
	public class Student
	{
		public long Ticket_number { get; set; }
		public Person Person { get; set; }
		public long Report_card { get; set; }
		public Group Group { get; set; }
	}
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(x => x.Ticket_number);
			builder.Property(x => x.Person).IsRequired();
			builder.Property(x => x.Report_card).IsRequired();
			builder.Property(x => x.Group).IsRequired();
		}
	}
}
