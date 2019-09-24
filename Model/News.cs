using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Data
{
	public class News
	{
		public string Name { get; set; }
		public string Photo { get; set; }
		public string Text { get; set; }
		public DateTime Time { get; set; }
	}
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
