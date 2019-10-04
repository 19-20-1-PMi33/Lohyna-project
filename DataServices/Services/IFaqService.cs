using System.Collections.Generic;
using System.Threading.Tasks;
using DataServices.DTO;

namespace DataServices.Services
{
    public interface IFaqService
    {
        Task<List<string>> LoadQuestionsAsync();
        Task<List<FAQ>> LoadAllFaqAsync();
    }
}