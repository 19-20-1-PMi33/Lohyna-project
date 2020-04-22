using System;

namespace Core.DTO
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set;  }
    }
}