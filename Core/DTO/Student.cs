using System;

namespace Core.DTO
{
    public class Student : Person
    {
        public long TicketNumber { get; set; }
        public long ReportCard { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
    }
}