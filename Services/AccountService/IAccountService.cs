using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Repositories.Persons;

namespace Services.AccountService
{
    public interface IAccountService
    {
        Task<Person> LoadPersonAsync(string username);
        Task CreateStudentAsync(Student s);
        bool ContainsPerson(Person p);
    }
}