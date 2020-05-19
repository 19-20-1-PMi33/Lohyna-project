using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repositories.Groups
{
    /// <summary>
    /// Service for obtaining data about groups.
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        /// Load group where the student is.
        /// </summary>
        /// <param name="student">Student, whose group is required.</param>
        /// <returns>Group where student is studying.</returns>
        Group LoadGroup(Student student);
        Group LoadGroup(string groupID);
        Task<IList<Group>> LoadGroupsAsync();
    }
}
