using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    /// <summary>
    /// Service for obtaining data about groups.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Load group where the student is.
        /// </summary>
        /// <param name="student">Student, whose group is required.</param>
        /// <returns>Group where student is studying.</returns>
        Group LoadGroup(Student student);
        Task<IList<Group>> LoadGroupsAsync();
    }
}
