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

        public void CreatePersonAsync(Person person)
        {
            _dbContext.Person.Add(person);
        }

        public async void CreateStudentAsync(Student student)
        {
            if (!_dbContext.Person.Contains(student.Person))
            {
                await _dbContext.Person.AddAsync(student.Person);
            }
            _dbContext.Student.AddAsync(student);
        }

        public Person LoadLogInPersonAsync(string username)
        {
            return _dbContext.Person.Find(username);
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
            _dbContext.Lecturer.AddAsync(lecturer);
        }
    }
}