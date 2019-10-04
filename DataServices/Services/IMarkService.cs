using System.Collections.Generic;
using System.Threading.Tasks;
using DataServices.DTO;

namespace DataServices.Services
{
    public interface IMarkService
    {
        Task<List<Rating>> LoadMarksAsync(Student student);
    }
}