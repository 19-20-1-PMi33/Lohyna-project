using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model
{
	public class Group
	{
		public string Name { get; set; }
		public int Size { get; set; }
		public int Course { get; set; }
	}
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Size).IsRequired();
			builder.Property(x => x.Course).IsRequired();
			builder.Property(x => x.Name).HasMaxLength(10);
		}
	}

}
