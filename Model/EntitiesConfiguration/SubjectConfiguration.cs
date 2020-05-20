using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
	{
		public void Configure(EntityTypeBuilder<Subject> builder)
		{
			builder.HasKey(x => x.Name);

			builder.Property(x => x.ExamType)
				.IsRequired();

			builder.HasMany(x => x.Lecturers)
				.WithOne(y => y.Subject)
				.HasForeignKey(y => y.SubjectID);

			builder.HasMany(x => x.Lessons)
				.WithOne(y => y.Subject)
				.HasForeignKey(y => y.SubjectID);

			builder.HasMany(x => x.Marks)
				.WithOne(y => y.Subject)
				.HasForeignKey(y => y.SubjectID);

			builder.HasMany(x => x.Notes)
				.WithOne(y => y.Subject)
				.HasForeignKey(y => y.SubjectID);

			builder.HasData(
			new Subject{Name="Digital image",ExamType="zalik"},
			new Subject{Name="Android",ExamType="zalik"},
			new Subject{Name="NodeJS",ExamType="zalik"},
			new Subject{Name="AI systems",ExamType="exam"},
			new Subject{Name="Computer methods",ExamType="exam"},
			new Subject{Name="Optimization methods",ExamType="exam"},
			new Subject{Name="Cryptology",ExamType="zalik"},
			new Subject{Name="PE",ExamType="exam"}
			);
		}
	}
}
