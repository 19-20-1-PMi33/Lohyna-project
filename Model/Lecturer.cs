using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Data
{
	public class Lecturer
	{
		public Person Person { get; set; }
		public string Department { get; set; }
	}
	public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
	{
		public void Configure(EntityTypeBuilder<Lecturer> builder)
		{
			builder.Property(x => x.Person).IsRequired();
			builder.Property(x => x.Department).IsRequired();
		}
	}

}
