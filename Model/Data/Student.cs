namespace Model.Data
{
	class Student
	{
		public Person Person { get; set; }
		public long Ticket_number { get; set; }
		public long Report_card { get; set; }
		public Group Group { get; set; }
	}
}
