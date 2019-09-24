using System;

namespace Model.Data
{
	class Note
	{
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Deadline { get; set; }
		public string Subject_Name { get; set; }
		public string Materials { get; set; }
	}
}
