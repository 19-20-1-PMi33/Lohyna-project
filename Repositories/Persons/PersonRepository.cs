using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _dbContext;

        public PersonRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task CreatePersonAsync(Person person)
        {
            await _dbContext.Person.AddAsync(person);
        }

        public async Task CreateStudentAsync(Student student)
        {
            if (!_dbContext.Person.Contains(student.Person))
            {
                await _dbContext.Person.AddAsync(student.Person);
                await _dbContext.SaveChangesAsync();
            }
            await _dbContext.Student.AddAsync(student);
        }

        public Person LoadLogInPersonAsync(string username)
        {
            return _dbContext.Person.Find(username);
        }

        public bool ContainsPerson(Person p)
        {
            return _dbContext.Person.Contains(p);
        }

        public async Task<List<Person>> SearchPersonByNameAsync(string name)
        {
            return await _dbContext.Person
                .Where(person => person.Name.ToLower().Equals(name.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Person>> SearchPersonBySurnameAsync(string surname)
        {
            return await _dbContext.Person
                .Where(person => person.Surname.ToLower().Equals(surname.ToLower()))
                .ToListAsync();
        }
        
        public async Task<List<Person>> LoadPersonAsync(string name)
        {
            return await _dbContext.Person
                .Where(person => person.Username.Equals(name))
                .ToListAsync();
        }

        public void UpdatePersonInfo(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;
        }

        public Student LoadStudent(Person person)
        {
            return _dbContext.Student.FirstOrDefault(p => p.Person.Username == person.Username);
        }

        public Lecturer LoadLecturer(Person person)
        {
            return _dbContext.Lecturer.FirstOrDefault(p => p.Person.Username == person.Username);
        }

        public Lecturer SearchLecturerById(int lecturerId)
        {
            return _dbContext.Lecturer.FirstOrDefault(p => p.ID == lecturerId);
        }

        public async void CreateLecturerAsync(Lecturer lecturer)
        {
            if (!_dbContext.Person.Contains(lecturer.Person))
            {
                await _dbContext.Person.AddAsync(lecturer.Person);
            }
            await _dbContext.Lecturer.AddAsync(lecturer);
        }

        public Achievment LoadLastAchievmentForStudent(Student student)
        {
            return _dbContext.Achievment.Where(x=>x.StudentID==student.TicketNumber).ToList().OrderBy(x=>x.Time).First();
        }
    }
}