using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
	{
		public void Configure(EntityTypeBuilder<Cabinet> builder)
		{
			builder.HasKey(x => x.Name);

			builder.Property(x => x.Size)
				.IsRequired();

			builder.Property(x => x.Name)
				.HasMaxLength(6);
		}
	}
}
