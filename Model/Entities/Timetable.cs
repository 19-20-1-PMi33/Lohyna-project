namespace Model
{
	public class Timetable
	{
		public int Id { get; set; }
		public string Day { get; set; } //Enum?
		public string Period { get; set; } //Enum?

		public Time Time { get; set; }
		public Subject Subject { get; set; }
		public Group Group { get; set; }
		public Lecturer Lecturer { get; set; }
	}
}
