using Microsoft.EntityFrameworkCore;
using Model;
using System.IO;
using Model.EntitiesConfiguration;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace Model
{
    /// <summary>
    /// Context of DB connection.
    /// </summary>
    public class LohynaDbContext : DbContext
    {
        public LohynaDbContext(DbContextOptions<LohynaDbContext> options) : base(options) {}

        /// <summary>
        /// Method of DB connection lifecycle.
        /// </summary>
        /// <param name="modelBuilder">DB models builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CabinetConfiguration());
            modelBuilder.ApplyConfiguration(new FAQConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new LecturerConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TimeConfiguration());
            modelBuilder.ApplyConfiguration(new TimetableConfiguration());
        }

        public DbSet<Cabinet> Cabinet { get; set; }

        public DbSet<FAQ> FAQ { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<Lecturer> Lecturer { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Note> Note { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Time> Time { get; set; }

        public DbSet<Timetable> Timetable { get; set; }

        public DbSet<Subject> Subject { get; set; }
    }
}
