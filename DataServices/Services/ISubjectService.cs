using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    /// <summary>
    /// Service for obtaining subjects' info.
    /// </summary>
    public interface ISubjectService
    {
        /// <summary>
        /// Load all the subjects.
        /// </summary>
        /// <returns>List of available subjects.</returns>
        Task<IList<Subject>> LoadSubjectsAsync();
    }
}
