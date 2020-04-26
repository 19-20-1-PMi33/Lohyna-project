using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Repositories.Subjects
{
    /// <summary>
    /// Service for obtaining subjects' info.
    /// </summary>
    public interface ISubjectRepository
    {
        /// <summary>
        /// Load all the subjects.
        /// </summary>
        /// <returns>List of available subjects.</returns>
        Task<IList<Subject>> LoadSubjectsAsync();
    }
}
