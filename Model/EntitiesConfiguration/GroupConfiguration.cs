using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		public void Configure(EntityTypeBuilder<Group> builder)
		{
			builder.HasKey(x => x.Name);

			builder.Property(x => x.Name)
				.HasMaxLength(10);

			builder.Property(x => x.Size)
				.IsRequired();

			builder.Property(x => x.Course)
				.IsRequired();

			builder.Property(x=>x.Faculty)
				.IsRequired();

			builder.HasMany(x => x.Students)
				.WithOne(y => y.Group)
				.HasForeignKey(y => y.GroupID);

			builder.HasMany(x => x.Lessons)
				.WithOne(y => y.Group)
				.HasForeignKey(y => y.GroupID);
			builder.HasData(new Group{Name="PMi-31",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"},
			new Group{Name="PMi-32",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"},
			new Group{Name="PMi-33",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"},
			new Group{Name="PMi-34",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"},
			new Group{Name="PMi-35",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"},
			new Group{Name="PMo-31",Size=20,Course=3,Faculty="Applied Mathematics and Informatics"});
		}
	}
}
