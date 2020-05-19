using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class PersonConfiguration : IEntityTypeConfiguration<Person>
	{
		public void Configure(EntityTypeBuilder<Person> builder)
		{
			builder.HasKey(x => x.Username);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Surname)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Password)
				.IsRequired()
				.HasMaxLength(16);

			builder.HasMany(x => x.Notes)
				.WithOne(y => y.Person)
				.HasForeignKey(y => y.PersonID);

			builder.HasOne(x => x.Lecturer)
				.WithOne(y => y.Person)
				.HasForeignKey<Lecturer>(y => y.PersonID);

			builder.HasOne(x => x.Student)
				.WithOne(y => y.Person)
				.HasForeignKey<Student>(y => y.PersonID);
			builder.HasData(new Person{Name="Iryna",Surname="Pozdnyakova",Password="iryna007",Username="iryna007"});
		}
	}
}
