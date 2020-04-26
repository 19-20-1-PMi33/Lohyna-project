using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

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
    }
}
