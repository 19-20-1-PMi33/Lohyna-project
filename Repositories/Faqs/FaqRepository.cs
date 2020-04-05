using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Faqs
{
    public class FaqRepository : IFaqRepository
    {
        private readonly AppDbContext _dbContext;

        public FaqRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public string LoadAnswerForQuestionAsync(string question)
        {
            return _dbContext.FAQ.Find(question).Answer;
        }
        
        public async Task<List<string>> LoadQuestionsAsync()
        {
            return await _dbContext.FAQ
                .Select(x => x.Question)
                .ToListAsync();
        }
        
        public async Task<List<FAQ>> LoadAllFaqAsync()
        {
            return await _dbContext.FAQ.ToListAsync();
        }
    }
}