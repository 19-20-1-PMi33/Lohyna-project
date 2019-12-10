using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    /// <summary>
    /// Service for obtaining timetable data.
    /// </summary>
    public interface ITimeTableService
    {
        /// <summary>
        /// Load person's timetable.
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Timetable of person.</returns>
        Task<IList<Timetable>> LoadTimetableAsync(string username);
		Person SearchLectorById(int LecturerID);
    }
}
