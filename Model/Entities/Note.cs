using System;

namespace Model
{
	public class Note
	{
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Deadline { get; set; }
		public string Materials { get; set; }
		public bool Finished { get; set; }

		public virtual Subject Subject { get; set; }
		public string SubjectID { get; set; }

		public virtual Person Person { get; set; }
		public string PersonID { get; set; }
	}
}
