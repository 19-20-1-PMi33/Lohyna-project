using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Created).IsRequired();
			builder.Property(x => x.Subject).IsRequired();
			builder.Property(x => x.Finished).IsRequired();
		}
	}
}
