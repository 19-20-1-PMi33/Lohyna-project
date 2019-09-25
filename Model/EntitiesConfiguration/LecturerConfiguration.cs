using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
	{
		public void Configure(EntityTypeBuilder<Lecturer> builder)
		{
			builder.HasKey(x => x.ID);
			// x.Person Foreign Key
			builder.Property(x => x.Person).IsRequired();
			builder.Property(x => x.Department).IsRequired();
		}
	}
}
