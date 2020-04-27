using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core;
using Model;
using Repositories.Persons;

namespace Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly PersonRepository repository;
        public AccountService(AppDbContext db){
            repository = new PersonRepository(db);
        }
        public async void CreateStudentAsync(Student s)
        {
            repository.CreateStudentAsync(s);
        }

        public async Task<Person> LoadPersonAsync(string username)
        {
            return repository.LoadLogInPersonAsync(username);
        }
    }
}