using System;

namespace Model
{
	public class Achievment
	{
		public int Id { get; set; }
		public string Text {get;set;}
        public string Photo {get;set;}
		public virtual Student Student { get; set; }
		public long StudentID { get; set; }
		public DateTime Time { get; set; }
	}
}
