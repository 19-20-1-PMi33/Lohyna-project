using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;
using System.IO;
using Model.EntitiesConfiguration;
using Microsoft.Data.Sqlite;

namespace DataServices
{
    public class SqliteDbContext : DbContext, IDataSource
    {
        private string _connectionString = null;
        public SqliteDbContext(string connectionString = null)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            // TODO: create adequate location for DB.
            connectionStringBuilder.DataSource = @"..\..\..\DataServices\univerity-db.db";
            _connectionString = connectionStringBuilder.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

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
    }
}
