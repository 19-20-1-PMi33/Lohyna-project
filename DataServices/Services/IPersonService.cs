using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface IPersonService
    {
        Task<List<Person>> LoadPersonAsync(string name);
        Task<Person> LoadLogInPersonAsync(string username);
    }
}