using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _dbContext;

        public SubjectRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public async Task<IList<Subject>> LoadSubjectsAsync()
        {
            return await _dbContext.Subject.ToListAsync();
        }
    }
}