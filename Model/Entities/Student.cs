using System.Collections.Generic;

namespace Model
{
	public class Student
	{
		public long TicketNumber { get; set; }
		public long ReportCard { get; set; }

		public virtual Person Person { get; set; }
		public string PersonID { get; set; }

		public virtual Group Group { get; set; }
		public string GroupID { get; set; }

		public ICollection<Rating> Marks { get; set; }
		public ICollection<Achievment> Achievments {get;set;}
	}
}