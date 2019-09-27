namespace Model
{
	public class Timetable
	{
		public int Id { get; set; }
		public string Subject { get; set; }
		public int Time { get; set; }
		public string Day { get; set; } //Enum?
		public string Period { get; set; } //Enum?
		public string Group { get; set; }
		public int Lecturer { get; set; }
	}
}
