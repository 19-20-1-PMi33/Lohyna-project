using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using System;

namespace Repositories.TimeTables
{
    /// <summary>
    /// Service for obtaining timetable data.
    /// </summary>
    public interface ITimeTableRepository
    {
        /// <summary>
        /// Load person's timetable.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Timetable of person.</returns>
        Task<IList<Timetable>> LoadTimetableAsync(Student student);
        Task<IList<Timetable>> LoadTimetableAsync(string groupID);
        Task<Timetable> LoadTimetableForTimeAsync(Student student,DateTime time);
    }
}
