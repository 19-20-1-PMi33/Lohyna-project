using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Persons
{
    public class PersonRepository : IPersonRepository
    {
        private readonly LohynaDbContext _dbContext;

        public PersonRepository(LohynaDbContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CreatePersonAsync(Person person)
        {
            _dbContext.Person.Add(person);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CreateStudentAsync(Student student)
        {
            _dbContext.Student.Add(student);
            return await _dbContext.SaveChangesAsync();
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


        public async Task<int> UpdatePersonInfo(Person person)
        {
            _dbContext.Entry(person).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }


        public Student LoadStudent(Person person)
        {
            return _dbContext.Student.FirstOrDefault(p => p.Person.Username == person.Username);
        }

        public Lecturer LoadLecturer(Person person)
        {
            return _dbContext.Lecturer.FirstOrDefault(p => p.Person.Username == person.Username);
        }

        public Person SearchLecturerById(int lecturerId)
        {
            string personId = _dbContext.Lecturer.FirstOrDefault(p => p.ID == lecturerId)?.PersonID;
            return _dbContext.Person.FirstOrDefault(p => p.Username.Equals(personId));
        }
    }
}