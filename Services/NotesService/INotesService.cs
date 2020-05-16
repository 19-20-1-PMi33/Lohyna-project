using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;

namespace Services.NotesService
{
    public interface INotesService
    {
        Task<List<Note>> LoadNotesAsync();
    }
}