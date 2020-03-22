using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Groups
{
    public class GroupRepository : IGroupRepository
    {
        private readonly LohynaDbContext _dbContext;

        public GroupRepository(LohynaDbContext context)
        {
            _dbContext = context;
        }
        
        public Group LoadGroup(Student student)
        {
            return _dbContext.Group.FirstOrDefault(p => p.Name == student.GroupID);
        }
        
        public async Task<IList<Group>> LoadGroupsAsync()
        {
            return await _dbContext.Group.ToListAsync();
        }
    }
}