using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Notes
{
    public class NoteRepository : INoteRepository
    {
        private readonly LohynaDbContext _dbContext;

        public NoteRepository(LohynaDbContext context)
        {
            _dbContext = context;
        }
        
        public async Task<int> CreateNoteAsync(Note note)
        {
            _dbContext.Note.Add(note);
            return await _dbContext.SaveChangesAsync();
        }
        
        public async Task<IList<Note>> LoadNotesAsync(string person)
        {
            return await _dbContext.Note
                .Where(note => note.Person.Username.Equals(person))
                .ToListAsync();
        }

        public async Task<IList<Note>> LoadNotesForSubject(string person, string subject)
        {
            return await _dbContext.Note
                .Where(note => note.Subject.Name.Equals(subject) && note.Person.Name.Equals(person))
                .ToListAsync();
        }
        
        public async Task<int> UpdateNoteAsync(Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }
        
        public async Task<int> DeleteNoteAsync(params Note[] note)
        {
            _dbContext.Note.RemoveRange(note);
            return await _dbContext.SaveChangesAsync();
        }
    }
}