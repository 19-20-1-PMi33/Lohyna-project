using System.Collections.Generic;

namespace Model
{
	public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Photo { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public virtual Student Student { get; set; }
		public virtual Lecturer Lecturer { get; set; }
		public ICollection<Note> Notes { get; set; }
	}
}
