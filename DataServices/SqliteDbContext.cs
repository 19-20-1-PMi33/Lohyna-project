using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataServices
{
    public class SqliteDbContext : DbContext, IDataSource
    {
        private string _connectionString = null;
        public SqliteDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        public DbSet<Cabinet> Cabinets { get; set; }

        public DbSet<FAQ> Faqs { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }

        public DbSet<News> Newses { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Time> Times { get; set; }

        public DbSet<Timetable> Timetables { get; set; }
    }
}
