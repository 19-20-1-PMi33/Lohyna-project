using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface IGroupService
    {
        Group LoadGroup(Student student);
    }
}
