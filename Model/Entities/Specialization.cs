namespace Model
{
	public class Specialization
	{
		public int ID { get; set; }

		public virtual Lecturer Lecturer { get; set; }
		public int LecturerID { get; set; }

		public virtual Subject Subject { get; set; }
		public string SubjectID { get; set; }
	}
}
