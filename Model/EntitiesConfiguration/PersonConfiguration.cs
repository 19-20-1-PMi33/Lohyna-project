using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Helpers;

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
			builder.HasData(new Person{Name="Iryna",Surname="Pozdnyakova",Password=AccountHelper.ComputeSha256Hash("iryna007"),Username="iryna007"},
			new Person{Name="Roman",Surname="Levkovych",Password=AccountHelper.ComputeSha256Hash("starosta"),Username="starosta",Photo="DbResources/Profile/profile1.png"},
			new Person{Name="Oleh",Surname="Andrus",Password=AccountHelper.ComputeSha256Hash("oleh"),Username="oleh",Photo="DbResources/Profile/profile2.jfif"},
			new Person{Name="Petro",Surname="Tarnavsky",Password=AccountHelper.ComputeSha256Hash("petro"),Username="petro",Photo="DbResources/Profile/profile3.png"},
			new Person{Name="Nikita",Surname="Zhaworonkow",Password=AccountHelper.ComputeSha256Hash("zhawa"),Username="zhawa",Photo="DbResources/Profile/profile4.png"});
		}
	}
}
