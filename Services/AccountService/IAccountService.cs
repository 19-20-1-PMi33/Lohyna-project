using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using Repositories.Persons;

namespace Services.AccountService
{
    public interface IAccountService
    {
        Person LoadPersonAsync(string username);
        Task CreateStudentAsync(Student s);
        bool ContainsPerson(Person p);
        Task<IList<Group>> GetGroupListAsync();
        IList<string> GetFacultyListAsync();
    }
}