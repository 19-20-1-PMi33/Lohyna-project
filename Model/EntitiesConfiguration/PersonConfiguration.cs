using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasKey(x => x.Username);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Password).IsRequired().HasMaxLength(16);
		}
	}
}
