using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(x => x.Name);

			builder.Property(x => x.Created)
				.IsRequired();

			builder.Property(x => x.Finished)
				.IsRequired();

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Notes)
				.HasForeignKey(x => x.SubjectID);

			builder.HasOne(x => x.Person)
				.WithMany(y => y.Notes)
				.HasForeignKey(x => x.PersonID);
		}
	}
}
