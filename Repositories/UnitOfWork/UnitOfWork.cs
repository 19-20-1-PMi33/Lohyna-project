using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Faqs;
using Repositories.Groups;
using Repositories.Marks;
using Repositories.Notes;
using Repositories.Persons;
using Repositories.Subjects;
using Repositories.TimeTables;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LohynaDbContext _dbContext;
        private bool _disposedValue = false;

        #region Repositories

        public IFaqRepository Faqs { get; }
        public IGroupRepository Groups { get; }
        public IMarkRepository Marks { get; }
        public INoteRepository Notes { get; }
        public ISubjectRepository Subjects { get; }
        public IPersonRepository Persons { get; }
        public ITimeTableRepository TimeTables { get; }

        #endregion

        UnitOfWork(LohynaDbContext context)
        {
            _dbContext = context;

            Faqs = new FaqRepository(_dbContext);
            Groups = new GroupRepository(_dbContext);
            Marks = new MarkRepository(_dbContext);
            Notes = new NoteRepository(_dbContext);
            Subjects = new SubjectRepository(_dbContext);
            Persons = new PersonRepository(_dbContext);
            TimeTables = new TimeTableRepository(_dbContext);
        }

        /// <inheritdoc />
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        await entry.ReloadAsync();
                        break;
                }
            }
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}