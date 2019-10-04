using System.Collections.Generic;

namespace Model
{
	public class Lecturer
	{
		public int ID { get; set; }
		public string Department { get; set; }

		public virtual Person Person { get; set; }
		public string PersonID { get; set; }

		public ICollection<Specialization> Specializations { get; set; }
		public ICollection<Timetable> Lessons { get; set; }
	}
}
