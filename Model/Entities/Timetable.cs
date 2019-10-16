namespace Model
{
	public class Timetable
	{
		public int Id { get; set; }
		public string Day { get; set; } //Enum?
		public string Period { get; set; } //Enum?

		public virtual Time Time { get; set; }
		public int TimeID { get; set; }

		public virtual Subject Subject { get; set; }
		public string SubjectID { get; set; }

		public virtual Group Group { get; set; }
		public string GroupID { get; set; }

		public virtual Lecturer Lecturer { get; set; }
		public int LecturerID { get; set; }
	}
}
