using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    public interface INoteService
    {
        Task<IList<Note>> LoadNotesAsync(string person);
        Task<IList<Note>> LoadNotesForSubject(string person, string subject);
        Task<Note> CreateNoteAsync(Note note);
        Task<int> DeleteNoteAsync(params Note[] note);
        Task<int> UpdateNoteAsync(Note note);
    }
}