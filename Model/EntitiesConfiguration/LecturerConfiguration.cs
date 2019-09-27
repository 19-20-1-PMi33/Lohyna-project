using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class LecturerConfiguration : IEntityTypeConfiguration<Lecturer>
	{
		public void Configure(EntityTypeBuilder<Lecturer> builder)
		{
			builder.HasKey(x => x.ID);
			builder.HasOne(x => x.Person).WithOne(y => y.Lecturer).HasForeignKey<Person>(y => y.Username);
			builder.Property(x => x.Department).IsRequired();
		}
	}
}
