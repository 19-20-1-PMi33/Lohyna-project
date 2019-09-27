using System.Collections.Generic;

namespace Model
{
	public class Group
	{
		public string Name { get; set; }
		public int Size { get; set; }
		public int Course { get; set; }
		
		public ICollection<Student> Students { get; set; }
	}
}
