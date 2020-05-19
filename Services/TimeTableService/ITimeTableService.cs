using System.Threading.Tasks;
using System.Collections.Generic;
using Core;

namespace Services.TimeTableService
{
    public interface ITimeTableService
    {
        Task<Dictionary<int, List<Core.DTO.Timetable>>> LoadTimetableForGroupAsync(string groupID);
    }
}
