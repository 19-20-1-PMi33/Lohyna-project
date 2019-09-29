using System.Collections.Generic;

namespace Model
{
	public class Lecturer
	{
		public int ID { get; set; }
		public string Department { get; set; }

		public Person Person { get; set; }
		public ICollection<Timetable> Lessons { get; set; }
	}
}
