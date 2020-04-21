using System;

namespace Core.DTO
{	
    public class Rating
	{
		public int Id { get; set; }
		public uint Mark { get; set; }
		public DateTime Time { get; set; }
		public string SubjectID { get; set; }
	}
}