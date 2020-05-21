using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.NotesService
{
    public interface INotesService
    {
        Task<IList<Model.Note>> LoadNotesAsync(string username);
        Task CreateNoteAsync(Model.Note note);
        Task<IList<Model.Subject>> LoadSubjectsAsync();
        void DeleteNoteAsync(Model.Note note);
        void UpdateNoteAsync(Model.Note note);
    }
}