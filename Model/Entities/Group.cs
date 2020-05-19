using System.Collections.Generic;

namespace Model
{
	public class Group
	{
		public string Name { get; set; }
		public long Size { get; set; }
		public long Course { get; set; }

		public string Faculty{get;set;}

		public ICollection<Student> Students { get; set; }
		public ICollection<Timetable> Lessons { get; set; }
	}
}
