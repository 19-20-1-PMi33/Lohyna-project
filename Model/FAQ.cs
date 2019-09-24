using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Model.Data
{
	public class FAQ
	{
		public string Question { get; set; }
		public string Answer { get; set; }
	}
	public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
	{
		public void Configure(EntityTypeBuilder<FAQ> builder)
		{
			builder.HasKey(x => x.Question);
			builder.Property(x => x.Answer).IsRequired();
		}
	}

}
