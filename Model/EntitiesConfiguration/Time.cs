using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class TimeConfiguration : IEntityTypeConfiguration<Time>
	{
		public void Configure(EntityTypeBuilder<Time> builder)
		{
			builder.HasKey(x => x.Number);

			builder.Property(x => x.Start)
				.IsRequired();

			builder.Property(x => x.Finish)
				.IsRequired();
		}
	}
}
