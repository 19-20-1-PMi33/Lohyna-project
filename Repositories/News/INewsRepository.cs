using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.News
{
    public interface INewsRepository
    {
        Task<List<Model.News>> LoadAllNewsAsync();
    }
}