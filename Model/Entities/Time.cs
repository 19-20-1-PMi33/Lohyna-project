using System;
using System.Collections.Generic;

namespace Model
{
	public class Time
	{
		public int Number { get; set; }
		public DateTime Start { get; set; }
		public DateTime Finish { get; set; }

		public ICollection<Timetable> Lessons { get; set; }
	}
}
