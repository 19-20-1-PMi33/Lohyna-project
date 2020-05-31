using System.Threading.Tasks;
using System.Collections.Generic;
using Core;
using Core.DTO;

namespace Services.TimeTableService
{
    public interface ITimeTableService
    {
        Dictionary<int, List<Timetable>> LoadTimetableForGroupAsync(string groupID);
    }
}
