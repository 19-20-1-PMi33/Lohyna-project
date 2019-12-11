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
		}
	}
}
