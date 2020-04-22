using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.TimeTableService
{
    public class TimeTableService: ITimeTableService
    {
        public async Task<List<Timetable>> LoadTimetableAsync()
        {
            List<Timetable> listTimetable = new List<Timetable>()
            {
                new Timetable { Id = 1, Day = "Monday", GroupID = "PMI-33", TimeID = 1, SubjectID = "PO", LecturerID = 1, Period = " "},
                new Timetable { Id = 2, Day = "Tuesday", GroupID = "PMI-33", TimeID = 2, SubjectID = "Numerical Methods", LecturerID = 1, Period = " "},
                new Timetable { Id = 3, Day = "Wednesday", GroupID = "PMI-33", TimeID = 1, SubjectID = "Cryptology", LecturerID = 1, Period = " "},
                new Timetable { Id = 4, Day = "Friday", GroupID = "PMI-33", TimeID = 4, SubjectID = "PO", LecturerID = 1, Period = " "}
            };   
            return listTimetable;
        }
    }
}
