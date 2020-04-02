using System.Collections.Generic;
using System.Threading.Tasks;
using Core;

namespace Services.NewsFeedService
{
    public interface INewsFeedService
    {
        Task<List<Core.DTO.News>> LoadNewsAsync();
    }
}