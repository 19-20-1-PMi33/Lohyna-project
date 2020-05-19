using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
	public class News
	{
		public string Name { get; set; }
		public string Photo { get; set; }
		public string Text { get; set; }
		public string Time { get; set; }
	}
}
