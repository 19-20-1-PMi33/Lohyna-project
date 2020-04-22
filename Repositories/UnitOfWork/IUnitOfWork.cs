using System.Threading.Tasks;
using Repositories.Faqs;
using Repositories.Groups;
using Repositories.Marks;
using Repositories.Notes;
using Repositories.Persons;
using Repositories.Subjects;
using Repositories.TimeTables;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Repositories
        public IFaqRepository Faqs { get; }
        public IGroupRepository Groups { get; }
        public IMarkRepository Marks { get; }
        public INoteRepository Notes { get; }
        public ISubjectRepository Subjects { get; }
        public IPersonRepository Persons { get; }
        public ITimeTableRepository TimeTables { get; }
        #endregion
        
        /// <summary>
        /// Commit changes asynchronously
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Rollback last transaction
        /// </summary>
        void Rollback();
    }
}