using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.NewsFeedService
{
    public interface INewsFeedService
    {
        Task<List<News>> LoadNewsAsync();
    }
}