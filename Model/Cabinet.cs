using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Model.Data
{
	public class Cabinet
	{
		public string Name { get; set; }
		public int Size { get; set; }
	}
	public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
	{
		public void Configure(EntityTypeBuilder<Cabinet> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Size).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(6);
		}
	}

}
