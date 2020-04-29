using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.News
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _dbContext;

        public NewsRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public Task<List<Model.News>> LoadAllNewsAsync()
        {
            return _dbContext.News.ToListAsync();
        }
    }
}