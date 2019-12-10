using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

namespace DataServices
{
    /// <summary>
    /// Data source for application.
    /// </summary>
    public interface IDataSource : IDisposable
    {
        /// <summary>
        /// Cabinets table in data source.
        /// </summary>
        DbSet<Cabinet> Cabinet { get; }

        /// <summary>
        /// FAQ table in data source.
        /// </summary>
        DbSet<FAQ> FAQ { get; }

        /// <summary>
        /// Groups table in data source.
        /// </summary>
        DbSet<Group> Group { get; }

        /// <summary>
        /// Lecturers table in data source.
        /// </summary>
        DbSet<Lecturer> Lecturer { get; }

        /// <summary>
        /// News table in data source.
        /// </summary>
        DbSet<News> News { get; }

        /// <summary>
        /// Notes table in data source.
        /// </summary>
        DbSet<Note> Note { get; }

        /// <summary>
        /// People table in data source.
        /// </summary>
        DbSet<Person> Person { get; }

        /// <summary>
        /// Ratings table in data source.
        /// </summary>
        DbSet<Rating> Rating { get; }

        /// <summary>
        /// Students table in data source.
        /// </summary>
        DbSet<Student> Student { get; }

        /// <summary>
        /// Time table in data source.
        /// </summary>
        DbSet<Time> Time { get; }

        /// <summary>
        /// Timetable table in data source.
        /// </summary>
        DbSet<Timetable> Timetable { get; }

        /// <summary>
        /// Subjects table in data source.
        /// </summary>
        DbSet<Subject> Subject { get; }

        /// <summary>
        /// Load entry from data source.
        /// </summary>
        /// <typeparam name="TEntity">Model in DB.</typeparam>
        /// <param name="entity">Entity to load from data source.</param>
        /// <returns>Object from DB.</returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Save all the data in DB synchronious.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Save all the data in DB asynchronous.
        /// </summary>
        /// <param name="cancellationToken">Cancel tocken.</param>
        /// <returns>Status of operation.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}