using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			builder.HasKey(x => x.TicketNumber);

			builder.Property(x => x.ReportCard)
				.IsRequired();

			//builder.HasOne(x => x.Person)
			//	.WithOne(y => y.Student)
   //             .HasForeignKey<Person>(y => y.Username);

            builder.HasOne(x => x.Group)
				.WithMany(y => y.Students)
				.HasForeignKey(x => x.GroupID);

			builder.HasMany(x => x.Marks)
				.WithOne(y => y.Student)
				.HasForeignKey(y => y.StudentID);
			builder.HasData(
			new Student{TicketNumber = 55555555,ReportCard=5555555,PersonID="cat", GroupID="PMi-33"},
			new Student{TicketNumber = 11111111,ReportCard=1111111,PersonID="starosta",GroupID="PMi-33"},
			new Student{TicketNumber = 22222222,ReportCard=2222222,PersonID="oleh",GroupID="PMi-32"},
			new Student{TicketNumber = 33333333,ReportCard=3333333,PersonID="petro",GroupID="PMi-31"},
			new Student{TicketNumber = 44444444,ReportCard=4444444,PersonID="zhawa",GroupID="PMi-34"});
		}
	}
}
