using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Services.ProfileService
{
    public interface IProfileService
    {
        Task<Core.DTO.PersonType> PersonTypeAsync(string username);
        Task<Core.DTO.Person> LoadPersonAsync(string username);

    }
}