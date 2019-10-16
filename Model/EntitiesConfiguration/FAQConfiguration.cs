using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
	{
		public void Configure(EntityTypeBuilder<FAQ> builder)
		{
			builder.HasKey(x => x.Question);

			builder.Property(x => x.Answer)
				.IsRequired();
		}
	}
}
