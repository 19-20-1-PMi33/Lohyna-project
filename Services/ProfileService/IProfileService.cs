using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Services.ProfileService
{
    public interface IProfileService
    {
        Task<Core.DTO.Person> LoadPersonAsync(string username);
    }
}