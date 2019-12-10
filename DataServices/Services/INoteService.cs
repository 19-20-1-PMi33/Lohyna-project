using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace DataServices.Services
{
    /// <summary>
    /// Service for obtaining person's notes.
    /// </summary>
    public interface INoteService
    {
        /// <summary>
        /// Load all the notes for given person.
        /// </summary>
        /// <param name="person">Person, whose notes was asked.</param>
        /// <returns>All the notes for the person.</returns>
        Task<IList<Note>> LoadNotesAsync(string person);

        /// <summary>
        /// Loads all the notes for given person for certain subject.
        /// </summary>
        /// <param name="person">Person, whose notes was asked.</param>
        /// <param name="subject">Subject for notes.</param>
        /// <returns>List of Notes.</returns>
        Task<IList<Note>> LoadNotesForSubject(string person, string subject);

        /// <summary>
        /// Creates new note.
        /// </summary>
        /// <param name="note">Note to save.</param>
        /// <returns>Status of operation.</returns>
        Task<int> CreateNoteAsync(Note note);

        /// <summary>
        /// Delete certain notes.
        /// </summary>
        /// <param name="note">Notes to be deleted.</param>
        /// <returns>Status of operation.</returns>
        Task<int> DeleteNoteAsync(params Note[] note);

        /// <summary>
        /// Updated a note in data source.
        /// </summary>
        /// <param name="note">Note to be updated.</param>
        /// <returns>Status of operation.</returns>
        Task<int> UpdateNoteAsync(Note note);
    }
}