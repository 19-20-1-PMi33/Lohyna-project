using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Model;

namespace Services.ProfileService
{
    public interface IProfileService
    {
        Student LoadStudentAsync(string username);
        string GetAuditoryForStudent(Model.Student student);
        Model.Achievment LoadLastAchievmentForStudent(Model.Student student);
    }
}