using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Model;
using Repositories.UnitOfWork;

namespace Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapProfile;

        public ProfileService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapProfile = mapper;
        }

        public string GetAuditoryForStudent(Student student)
        {
            var timetable = _unitOfWork.TimeTables.LoadTimetableForTimeAsync(student,DateTime.Now).Result;
            if(timetable.Id!=-1)
            {
                return timetable.Auditory;
            }
            return "";
        }

        public Achievment LoadLastAchievmentForStudent(Student student)
        {
            return _unitOfWork.Persons.LoadLastAchievmentForStudent(student);
        }

        public Student LoadStudentAsync(string username)
        {
            var person = _unitOfWork.Persons.LoadLogInPersonAsync(username);
            var student = _unitOfWork.Persons.LoadStudent(person);
            student.Group = _unitOfWork.Groups.LoadGroup(student.GroupID);
            return student;
        }
    }
}