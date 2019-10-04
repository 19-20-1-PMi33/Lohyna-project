using System.Collections.Generic;
using System.Threading.Tasks;
using DataServices.DTO;

namespace DataServices.Services
{
    public interface ITimeTableService
    {
        Task<IList<Timetable>> LoadTimetableAsync(Person person);
    }
}