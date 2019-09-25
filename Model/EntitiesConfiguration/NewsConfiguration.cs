using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class NewsConfiguration : IEntityTypeConfiguration<News>
	{
		public void Configure(EntityTypeBuilder<News> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Text).IsRequired();
			builder.Property(x => x.Time).IsRequired();
		}
	}
}
