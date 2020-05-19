using System;
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

        public async Task<Timetable> LoadTimetableForTimeAsync(Student student, DateTime time)
        {
            var timetable = LoadTimetableAsync(student).Result.Where(x=>x.Day.ToLower()==time.DayOfWeek.ToString().ToLower());
            foreach(var timeTableItem in timetable)
            {
                var timeTableTime = _dbContext.Time.Find(timeTableItem.TimeID);
                if(TimeSpan.Compare(timeTableTime.Start.TimeOfDay,time.TimeOfDay)<0&&TimeSpan.Compare(time.TimeOfDay,timeTableTime.Finish.TimeOfDay)<0)
                    return timeTableItem;
            }
            return new Timetable{Id=-1};
        }
    }
}