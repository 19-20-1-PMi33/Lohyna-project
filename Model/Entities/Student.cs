using System.Collections.Generic;

namespace Model
{
	public class Student
	{
		public long TicketNumber { get; set; }
		public long ReportCard { get; set; }

		public Person Person { get; set; }
		public Group Group { get; set; }
		public ICollection<Rating> Marks { get; set; }
	}
}
