namespace Model
{
	public class Lecturer
	{
		public int ID { get; set; }
		public string Department { get; set; }
		public virtual Person Person { get; set; }
	}
}
