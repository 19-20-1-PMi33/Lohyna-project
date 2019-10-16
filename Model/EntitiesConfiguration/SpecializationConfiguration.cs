using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
	{
		public void Configure(EntityTypeBuilder<Specialization> builder)
		{
			builder.HasKey(x => x.ID);

			builder.HasOne(x => x.Lecturer)
				.WithMany(y => y.Specializations)
				.HasForeignKey(x => x.LecturerID);

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Lecturers)
				.HasForeignKey(x => x.SubjectID);
		}
	}
}
