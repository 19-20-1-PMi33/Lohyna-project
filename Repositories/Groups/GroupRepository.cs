using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Groups
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _dbContext;

        public GroupRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public Group LoadGroup(Student student)
        {
            return _dbContext.Group.FirstOrDefault(p => p.Name == student.GroupID);
        }

        public Group LoadGroup(string groupID)
        {
            return _dbContext.Group.Find(groupID);
        }

        public async Task<IList<Group>> LoadGroupsAsync()
        {
            return await _dbContext.Group.ToListAsync();
        }
    }
}