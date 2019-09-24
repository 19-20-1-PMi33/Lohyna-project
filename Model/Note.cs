using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Data
{
	public class Note
	{
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Deadline { get; set; }
		public string Subject_Name { get; set; }
		public string Materials { get; set; }
	}
	public class NoteConfiguration : IEntityTypeConfiguration<Note>
	{
		public void Configure(EntityTypeBuilder<Note> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Created).IsRequired();
			builder.Property(x => x.Subject_Name).HasMaxLength(40);
		}
	}
}
