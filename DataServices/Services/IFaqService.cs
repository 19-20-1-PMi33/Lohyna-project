using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface IFaqService
    {
        Task<List<string>> LoadQuestionsAsync();
        Task<List<FAQ>> LoadAllFaqAsync();
    }
}