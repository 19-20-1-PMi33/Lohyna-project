namespace Model
{
	public class Rating
	{
		public int Id { get; set; }
		public uint Mark { get; set; }

		public Student Student { get; set; }
		public Subject Subject { get; set; }
	}
}
