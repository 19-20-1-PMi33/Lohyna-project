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


        public async Task<Student> LoadStudentAsync(string username)
        {
            Model.Person person = _unitOfWork.Persons.LoadLogInPersonAsync(username);
            Model.Student student = _unitOfWork.Persons.LoadStudent(person);
            student.Group = _unitOfWork.Groups.LoadGroup(student.GroupID);
            return student;
        }
    }
}