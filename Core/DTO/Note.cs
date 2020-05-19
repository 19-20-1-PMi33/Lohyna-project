using System;

namespace Core.DTO
{	

	public enum  SortState
	{
		NameAsc,
		NameDesc,
		CreatedAsc,
		CreatedDesc,
		DeadlineAsc,
		DeadlineDesc
	}

	public class Note
	{
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public DateTime Deadline { get; set; }
		public string Materials { get; set; }
		public bool Finished { get; set; }
		public string SubjectID { get; set; }
		public string PersonID { get; set; }
	}
}