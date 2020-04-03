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
            List<Timetable> listTimetable = new List<Timetable>();   
            return listTimetable;
        }
    }
}
