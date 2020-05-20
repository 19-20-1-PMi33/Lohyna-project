using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Services.ProfileService
{
    public interface IProfileService
    {
        Task<Model.Student> LoadStudentAsync(string username);
        string GetAuditoryForStudent(Model.Student student);
    }
}