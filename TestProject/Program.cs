using System;
using DataServices;
using DataServices.DTO;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var item = new SqliteDbContext("asdf"))
            {
                item.Group.Add(new Model.Group { Course = 1, Name = "p2as", Size = 12, Lessons = null, Students = null });

                item.SaveChanges();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
