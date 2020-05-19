using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.TimeTables
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private readonly AppDbContext _dbContext;

        public TimeTableRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public async Task<IList<Timetable>> LoadTimetableAsync(Student student)
        {
            return await _dbContext.Timetable
                .Where(item => item.GroupID.Equals(student.GroupID))
                .ToListAsync();

        }

        public async Task<IList<Timetable>> LoadTimetableAsync(string groupID)
        {
            return await _dbContext.Timetable
                .Where(item => item.GroupID.Equals(groupID))
                .ToListAsync();
        }
    }
}