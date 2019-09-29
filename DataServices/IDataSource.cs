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
        DbSet<Cabinet> Cabinets { get; }
        DbSet<FAQ> Faqs { get; }
        DbSet<Group> Groups { get; }
        DbSet<Lecturer> Lecturers { get; }
        DbSet<News> Newses { get; }
        DbSet<Note> Notes { get; }
        DbSet<Person> Persons { get; }
        DbSet<Rating> Ratings { get; }
        DbSet<Student> Students { get; }
        DbSet<Time> Times { get; }
        DbSet<Timetable> Timetables { get; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}