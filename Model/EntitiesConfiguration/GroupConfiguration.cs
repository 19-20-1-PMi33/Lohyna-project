﻿using Microsoft.EntityFrameworkCore;
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

			builder.HasMany(x => x.Students)
				.WithOne(x => x.Group);

			builder.HasMany(x => x.Lessons)
				.WithOne(x => x.Group);
		}
	}
}
