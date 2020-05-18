using System;

namespace Core.DTO
{
    public class News
    {
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Text { get; set; }
        public DateTime TimePosted { get; set;  }
    }
}