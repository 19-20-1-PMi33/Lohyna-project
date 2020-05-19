using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
	public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
	{
		public void Configure(EntityTypeBuilder<Timetable> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Day)
				.IsRequired();

			builder.Property(x => x.Period);

			builder.HasOne(x => x.Time)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.TimeID);

			builder.HasOne(x => x.Subject)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.SubjectID);

			builder.HasOne(x => x.Group)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.GroupID);

			builder.HasOne(x => x.Lecturer)
				.WithMany(y => y.Lessons)
				.HasForeignKey(x => x.LecturerID);

			builder.HasData(
			new Timetable{Id=1,Day="Monday",Period="all",
			TimeID=5,SubjectID="Digital image",GroupID="PMi-33",LecturerID=1},
			new Timetable{Id=2,Day="Monday",Period="all",
			TimeID=5,SubjectID="Android",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=3,Day="Monday",Period="all",
			TimeID=5,SubjectID="NodeJS",GroupID="PMi-31",LecturerID=1},

			new Timetable{Id=4,Day="Monday",Period="all",
			TimeID=6,SubjectID="Digital image",GroupID="PMi-33",LecturerID=1},
			new Timetable{Id=5,Day="Monday",Period="all",
			TimeID=6,SubjectID="Android",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=12,Day="Monday",Period="all",
			TimeID=6,SubjectID="NodeJS",GroupID="PMi-31",LecturerID=1},

			new Timetable{Id=6,Day="Tuesday",Period="all",
			TimeID=3,SubjectID="AI systems",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=7,Day="Tuesday",Period="all",
			TimeID=3,SubjectID="AI systems",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=8,Day="Tuesday",Period="all",
			TimeID=3,SubjectID="AI systems",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=9,Day="Tuesday",Period="all",
			TimeID=4,SubjectID="Computer methods",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=10,Day="Tuesday",Period="all",
			TimeID=4,SubjectID="Computer methods",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=11,Day="Tuesday",Period="all",
			TimeID=4,SubjectID="Computer methods",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=13,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=14,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=15,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=37,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=38,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=39,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=16,Day="Wednesday",Period="all",
			TimeID=4,SubjectID="Cryptology",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=17,Day="Wednesday",Period="all",
			TimeID=4,SubjectID="Cryptology",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=18,Day="Wednesday",Period="all",
			TimeID=4,SubjectID="Cryptology",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=19,Day="Wednesday",Period="all",
			TimeID=5,SubjectID="Computer methods",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=20,Day="Wednesday",Period="all",
			TimeID=5,SubjectID="Cryptology",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=21,Day="Wednesday",Period="all",
			TimeID=5,SubjectID="Optimization methods",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=22,Day="Tuesday",Period="all",
			TimeID=6,SubjectID="Cryptology",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=23,Day="Wednesday",Period="all",
			TimeID=6,SubjectID="AI systems",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=24,Day="Wednesday",Period="all",
			TimeID=6,SubjectID="Cryptology",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=25,Day="Thursday",Period="all",
			TimeID=5,SubjectID="Optimization methods",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=26,Day="Thursday",Period="all",
			TimeID=5,SubjectID="Optimization methods",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=27,Day="Thursday",Period="all",
			TimeID=5,SubjectID="Optimization methods",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=28,Day="Thursday",Period="all",
			TimeID=2,SubjectID="Cryptology",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=29,Day="Friday",Period="all",
			TimeID=7,SubjectID="Optimization methods",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=30,Day="Thursday",Period="all",
			TimeID=5,SubjectID="Computer methods",GroupID="PMi-33",LecturerID=1},

			new Timetable{Id=31,Day="Friday",Period="all",
			TimeID=4,SubjectID="PE",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=32,Day="Friday",Period="all",
			TimeID=4,SubjectID="PE",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=33,Day="Friday",Period="all",
			TimeID=4,SubjectID="PE",GroupID="PMi-33",LecturerID=1},
			
			new Timetable{Id=34,Day="Friday",Period="all",
			TimeID=5,SubjectID="PE",GroupID="PMi-31",LecturerID=1},
			new Timetable{Id=35,Day="Friday",Period="all",
			TimeID=5,SubjectID="Computer methods",GroupID="PMi-32",LecturerID=1},
			new Timetable{Id=36,Day="Friday",Period="all",
			TimeID=3,SubjectID="PE",GroupID="PMi-33",LecturerID=1}
			);
		}
	}
}
