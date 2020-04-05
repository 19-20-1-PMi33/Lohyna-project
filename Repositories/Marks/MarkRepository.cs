using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Marks
{
    public class MarkRepository : IMarkRepository
    {
        private readonly AppDbContext _dbContext;

        public MarkRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public async Task<List<Rating>> LoadMarksAsync(Student student)
        {
            return await _dbContext.Rating
                .Where(row => row.Student.Equals(student))
                .ToListAsync();
        }
    }
}