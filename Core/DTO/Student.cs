using System;

namespace Core.DTO
{
	public class Student:Person
	{
		public long TicketNumber { get; set; }
		public long ReportCard { get; set; }
		public string GroupID { get; set; }
        public string Faculty {get; set; }
	}
}