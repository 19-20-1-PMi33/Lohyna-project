namespace Model
{
	public class Rating
	{
		public int Id { get; set; }
		public uint Mark { get; set; }

		public virtual Student Student { get; set; }
		public string StudentID { get; set; }

		public virtual Subject Subject { get; set; }
		public string SubjectID { get; set; }
	}
}
