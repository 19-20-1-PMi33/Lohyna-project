using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core;
using Model;
using Repositories.UnitOfWork;

namespace Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public async Task CreateStudentAsync(Student s)
        {
            s.Group = _unitOfWork.Groups.LoadGroup(s.GroupID);
            await _unitOfWork.Persons.CreateStudentAsync(s);
            await _unitOfWork.CommitAsync();
        }

        public Person LoadPersonAsync(string username)
        {
            return  _unitOfWork.Persons.LoadLogInPersonAsync(username);
        }

        public bool ContainsPerson(Person p)
        {
            return _unitOfWork.Persons.ContainsPerson(p);
        }

        public async Task<IList<Group>> GetGroupListAsync()
        {
            return  await _unitOfWork.Groups.LoadGroupsAsync();
        }

        public IList<string> GetFacultyListAsync()
        {
            return (GetGroupListAsync().Result as List<Group>).Select(x=>x.Faculty).Distinct().OrderBy(x=>x).ToList();
        }
    }
}