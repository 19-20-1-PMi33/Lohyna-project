using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Model
{
	public class Note
	{
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Deadline { get; set; }
		public string SubjectName { get; set; }
		public string Materials { get; set; }
		public bool Finished { get; set; }
	}
	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Created).IsRequired();
			builder.Property(x => x.SubjectName).HasMaxLength(40);
			builder.Property(x => x.Finished).IsRequired();
		}
	}
}
