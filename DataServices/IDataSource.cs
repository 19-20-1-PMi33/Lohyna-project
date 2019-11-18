using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace DataServices
{
    public interface IDataSource : IDisposable
    {
        DbSet<Cabinet> Cabinet { get; }
        DbSet<FAQ> FAQ { get; }
        DbSet<Group> Group { get; }
        DbSet<Lecturer> Lecturer { get; }
        DbSet<News> News { get; }
        DbSet<Note> Note { get; }
        DbSet<Person> Person { get; }
        DbSet<Rating> Rating { get; }
        DbSet<Student> Student { get; }
        DbSet<Time> Time { get; }
        DbSet<Timetable> Timetable { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}