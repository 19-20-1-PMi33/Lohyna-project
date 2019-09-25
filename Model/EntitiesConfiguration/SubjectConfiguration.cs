using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.ExamType).IsRequired();
			builder.Property(x => x.Lecturer).IsRequired();
		}
	}
}
