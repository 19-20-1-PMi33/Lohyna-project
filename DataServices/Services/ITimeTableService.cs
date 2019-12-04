using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface ITimeTableService
    {
        Task<IList<Timetable>> LoadTimetableAsync(Person person);
		Person SearchLectorById(int LecturerID);
	}
}