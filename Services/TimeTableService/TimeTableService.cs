using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using Core.DTO;
using Repositories.UnitOfWork;

namespace Services.TimeTableService
{
    public class TimeTableService : ITimeTableService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public TimeTableService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Dictionary<int, List<Timetable>> LoadTimetableForGroupAsync(string groupID)
        {
            Dictionary<string, int> daysOfWeek = new Dictionary<string, int>()
            {
                ["Monday"] = 0,
                ["Tuesday"] = 1,
                ["Wednesday"] = 2,
                ["Thursday"] = 3,
                ["Friday"] = 4
            };
            List<Timetable> res = new List<Timetable>();
            (_unitOfWork.TimeTables.LoadTimetableAsync(groupID).Result as List<Model.Timetable>).ForEach(x =>
                res.Add(_mapper.Map<Core.DTO.Timetable>(x)));
            res.ForEach(x =>
            {
                var lecturer = _unitOfWork.Persons.SearchLecturerById(x.LecturerID);
                var person = _unitOfWork.Persons.LoadLogInPersonAsync(lecturer.PersonID);
                var lecturerName = person.Name + " " + person.Surname;
                x.LecturerName = lecturerName;
            });
            var result = res
                .GroupBy(x => x.TimeID)
                .ToDictionary(x => x.Key,
                    x => x.OrderBy(x => daysOfWeek[x.Day]).ToList())
                .OrderBy(k => k.Key)
                .ToDictionary(z => z.Key, y => y.Value);
            return result;
        }
    }
}