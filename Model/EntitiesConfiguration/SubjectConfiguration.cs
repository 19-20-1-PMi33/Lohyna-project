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
				new Subject{Name = "PE", ExamType = "Exam"},
				new Subject{Name = "Math", ExamType = "Zalik"},
				new Subject{Name = "Cryptology", ExamType = "Zalik"},
				new Subject{Name = "Numerical methods", ExamType = "Zalik"}
			);
		}
	}
}
