using System.Collections.Generic;

namespace Model
{
	public class Subject
	{
		public string Name { get; set; }
		public string ExamType { get; set; }

		public ICollection<Specialization> Lecturers { get; set; }
		public ICollection<Rating> Marks { get; set; }
		public ICollection<Timetable> Lessons { get; set; }
		public ICollection<Note> Notes { get; set; }
	}
}
