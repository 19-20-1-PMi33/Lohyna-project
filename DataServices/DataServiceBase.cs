using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using DataServices.Services;

namespace DataServices
{
    public abstract class DataServiceBase : IDisposable, IDataService
    {
        private IDataSource _dataSource = null;

        public DataServiceBase(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public async Task<int> CreateNoteAsync(Note note)
        {
            _dataSource.Note.Add(note);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> DeleteNoteAsync(params Note[] note)
        {
            _dataSource.Note.RemoveRange(note);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<List<FAQ>> LoadAllFaqAsync()
        {
            return await _dataSource.FAQ.ToListAsync();
        }

        public Person LoadLogInPersonAsync(string username)
        {
            return _dataSource.Person.Find(username);
        }

        public async Task<List<Rating>> LoadMarksAsync(Student student)
        {
            return await _dataSource.Rating
                .Where(row => row.Student.Equals(student))
                .ToListAsync();
        }

        public async Task<IList<Note>> LoadNotesAsync(string person)
        {
            return await _dataSource.Note
                .Where(note => note.Person.Username.Equals(person))
                .ToListAsync();
        }

        public async Task<IList<Note>> LoadNotesForSubject(string person, string subject)
        {
            return await _dataSource.Note
                .Where(note => note.Subject.Name.Equals(subject) && note.Person.Name.Equals(person))
                .ToListAsync();
        }

        public async Task<List<Person>> LoadPersonAsync(string name)
        {
            return await _dataSource.Person
                .Where(person => person.Username.Equals(name))
                .ToListAsync();
        }
        public async Task<List<Person>> SearchPersonByNameAsync(string name)
        {
            return await _dataSource.Person
                .Where(person => person.Name.Equals(name))
                .ToListAsync();
        }
        public async Task<List<Person>> SearchPersonBySurnameAsync(string surname)
        {
            return await _dataSource.Person
                .Where(person => person.Surname.Equals(surname))
                .ToListAsync();
        }

        public async Task<List<string>> LoadQuestionsAsync()
        {
            return await _dataSource.FAQ
                .Select(x => x.Question)
                .ToListAsync();
        }

        public async Task<IList<Timetable>> LoadTimetableAsync(Person person)
        {
			return await _dataSource.Timetable
				.Select(item => item)
				.ToListAsync();

			return await _dataSource.Timetable
                .Where(item => item.Group.Equals(person.Student.Group))
                .ToListAsync();
        }

        public async Task<int> UpdateNoteAsync(Note note)
        {
            _dataSource.Entry(note).State = EntityState.Modified;

            return await _dataSource.SaveChangesAsync();
        }

        public async Task<int> UpdatePersonInfo(Person person)
        {
            _dataSource.Entry(person).State = EntityState.Modified;

            return await _dataSource.SaveChangesAsync();
        }

        public string LoadAnswerForQuestionAsync(string question)
        {
            return _dataSource.FAQ.Find(question).Answer;
        }

        string IFaqService.LoadAnswerForQuestionAsync(string question)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Subject>> LoadSubjectsAsync()
        {
            return await _dataSource.Subject.ToListAsync();
        }

        public Student LoadStudent(Person person)
        {
            return _dataSource.Student.FirstOrDefault(p=>p.Person==person);
        }

        public Lecturer LoadLecturer(Person person)
        {
            return _dataSource.Lecturer.FirstOrDefault(p => p.Person == person);
        }

		public Person SearchLectorById(int LecturerID)
		{
			string PersonID = _dataSource.Lecturer.FirstOrDefault(p => p.ID == LecturerID).PersonID;
			return _dataSource.Person.FirstOrDefault(p => p.Username.Equals(PersonID));
		}

		#region Disposable
		public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataSource != null)
                {
                    _dataSource.Dispose();
                }
            }
        }
		#endregion
	}
}
