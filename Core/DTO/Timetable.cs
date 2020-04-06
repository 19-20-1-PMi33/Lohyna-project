using System;

namespace Core.DTO
{
    public class Timetable
    {
        public int Id { get; set; }
		public string Day { get; set; } 
		public string Period { get; set; }
        public int TimeID { get; set; }
		public string SubjectID { get; set; }
		public string GroupID { get; set; }
		public int LecturerID { get; set; }
    }
}
