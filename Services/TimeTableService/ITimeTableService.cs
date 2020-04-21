﻿using System.Threading.Tasks;
using System.Collections.Generic;
using Core;

namespace Services.TimeTableService
{
    public interface ITimeTableService
    {
        Task<List<Core.DTO.Timetable>> LoadTimetableAsync();
    }
}
