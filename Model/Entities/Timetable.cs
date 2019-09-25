namespace Model
{
	public class Timetable
	{
		public int Id { get; set; }
		public Subject Subject { get; set; }
		public Time Time { get; set; }
		public string Day { get; set; }
		public string Period { get; set; }
		public Group Group { get; set; }
		public Lecturer Lecturer { get; set; }
	}
}
