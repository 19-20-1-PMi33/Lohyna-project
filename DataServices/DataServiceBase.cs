using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
using System.Linq;

using Microsoft.EntityFrameworkCore;

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

        public Task<Person> LoadLogInPersonAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Rating>> LoadMarksAsync(Student student)
        {
            return await _dataSource.Rating.Where(row => row.Student.Equals(student)).ToListAsync();
        }

        public Task<IList<Note>> LoadNotesAsync(string person)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Note>> LoadNotesForSubject(string person, string subject)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> LoadPersonAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> LoadQuestionsAsync()
        {
            return await _dataSource.FAQ.Select(x => x.Question).ToListAsync();
        }

        public Task<IList<Timetable>> LoadTimetableAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateNoteAsync(Note note)
        {
            throw new NotImplementedException();
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
