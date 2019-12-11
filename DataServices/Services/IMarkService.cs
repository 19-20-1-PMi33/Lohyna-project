using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    /// <summary>
    /// Service for obtaining data abouts student's marks.
    /// </summary>
    public interface IMarkService
    {
        /// <summary>
        /// Load marks for given student.
        /// </summary>
        /// <param name="student">Student, whose marks are asked.</param>
        /// <returns>List of subjects and marks.</returns>
        Task<List<Rating>> LoadMarksAsync(Student student);
    }
}