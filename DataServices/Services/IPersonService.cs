using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface IPersonService
    {
        Task<List<Person>> LoadPersonAsync(string name);
        Task<int> UpdatePersonInfo(Person person);
        Person LoadLogInPersonAsync(string username);
        Student LoadStudent(Person person);
        Lecturer LoadLecturer(Person person);
        
    }
}