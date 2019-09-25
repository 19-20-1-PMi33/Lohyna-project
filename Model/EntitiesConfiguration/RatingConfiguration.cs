using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Student).IsRequired();
			builder.Property(x => x.Subject).IsRequired();
			builder.Property(x => x.Mark).IsRequired();
		}
	}

}
