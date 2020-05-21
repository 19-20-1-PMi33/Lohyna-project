using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repositories.Notes
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _dbContext;

        public NoteRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        
        public void CreateNoteAsync(Note note)
        {
            _dbContext.Note.AddAsync(note);
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
        
        public void UpdateNoteAsync(Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;
        }
        
        public void DeleteNoteAsync(Note note)
        {
            _dbContext.Note.Remove(note);
        }
    }
}