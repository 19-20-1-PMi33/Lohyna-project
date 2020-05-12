using System;
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
        private IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork){
            _unitOfWork = unitOfWork;
        }
        public async Task CreateStudentAsync(Student s)
        {
            await _unitOfWork.Persons.CreateStudentAsync(s);
        }

        public async Task<Person> LoadPersonAsync(string username)
        {
            return _unitOfWork.Persons.LoadLogInPersonAsync(username);
        }

        public bool ContainsPerson(Person p)
        {
            return _unitOfWork.Persons.ContainsPerson(p);
        }
    }
}