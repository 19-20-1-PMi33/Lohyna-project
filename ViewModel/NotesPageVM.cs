using System;
using System.Collections.Generic;
using System.Text;
using DataServices.Services;
using DataServices;
using Model;

namespace ViewModel
{
    /// <summary>
    /// Enum to store types of sorting events
    /// </summary>
    public enum SortedBy { Created, CreatedReverse, Deadline, DeadlineReverse, Subject, SubjectReverse, Title, TitleReverse };
    public class NotesPageVM
    {
        INoteService noteService;
        private List<Note> notes;
        private string username;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="noteService">Service to connect to database</param>
        /// <param name="username">Username of logedIn person</param>
        public NotesPageVM(INoteService noteService,string username)
        {
            this.noteService = noteService;
            this.username = username;
        }
        /// <summary>
        /// Seek for all notes of current user
        /// </summary>
        /// <returns></returns>
        public IList<Note> GetNotes()
        {
            if(notes == null)
            {
                notes = (List<Note>)noteService.LoadNotesAsync(username).Result;
            }
            return notes;
        }
        /// <summary>
        /// Delete note by title
        /// </summary>
        /// <param name="note">Title of note</param>
        public void DeleteNote(string note)
        {
            Note rm=null;
            notes.ForEach(x => {if (x.Name == note)
                {
                    rm = x;
                    noteService.DeleteNoteAsync(x).Wait();
                }
            });
            if (rm != null)
            {
                notes.Remove(rm);
            }
        }
        /// <summary>
        /// Delete couple of notes by titles
        /// </summary>
        /// <param name="notesToDelete">List with note titles</param>
        public void DeleteNotes(List<String> notesToDelete)
        {
            List<Note> rm = new List<Note>();
            notes.ForEach(x => {
                if (notesToDelete.Contains(x.Name))
                {
                    rm.Add(x);
                    noteService.DeleteNoteAsync(x).Wait();
                }
            });
            if (rm.Count > 0)
            {
                rm.ForEach(x => notes.Remove(x));
            }
        }
        /// <summary>
        /// Get all subjects current user has
        /// </summary>
        /// <returns>List of subject names</returns>
        public List<String> GetSubjects()
        {
            List<String> res = new List<string>();
            foreach (Subject s in (new SQLiteDataService()).LoadSubjectsAsync().Result)
            {
                res.Add(s.Name);
            }
            return res;
        }
        /// <summary>
        /// Add new note from strings
        /// </summary>
        /// <param name="title">Title of note</param>
        /// <param name="date">Deadline of note</param>
        /// <param name="subject">Subject of note</param>
        /// <param name="text">Text of note</param>
        public void AddNote(string title, string date,string subject, string text)
        {
            Note n = new Note { Created = DateTime.Now, Deadline = DateTime.Parse(date), Finished = false, Name = title, PersonID = username, Materials = text, SubjectID = subject };
            notes.Add(n);
            noteService.CreateNoteAsync(n).Wait();
        }
        /// <summary>
        /// Change existing note data
        /// </summary>
        /// <param name="note">Old note</param>
        /// <param name="newNote">Note with changes</param>
        public void UpdateNote(Note note, Note newNote)
        {
            newNote.PersonID = username;
            var del = noteService.DeleteNoteAsync(note);
            var add = noteService.CreateNoteAsync(newNote);
            notes.Remove(note);
            notes.Add(newNote);
            del.Wait();
            add.Wait();
        }
        /// <summary>
        /// Sort by different parameters
        /// </summary>
        /// <param name="key">Key to sort by</param>
        public void sort(SortedBy key)
        {
            if (notes.Count > 1)
            {
                switch (key)
                {
                    case SortedBy.Created: notes.Sort((x, y) => x.Created.CompareTo(y.Created)); break;
                    case SortedBy.CreatedReverse: notes.Sort((x, y) => y.Created.CompareTo(x.Created)); break;
                    case SortedBy.Deadline: notes.Sort((x, y) => x.Deadline.CompareTo(y.Deadline)); break;
                    case SortedBy.DeadlineReverse: notes.Sort((x, y) => y.Deadline.CompareTo(x.Deadline)); break;
                    case SortedBy.Subject: notes.Sort((x, y) => x.SubjectID.CompareTo(y.SubjectID)); break;
                    case SortedBy.SubjectReverse: notes.Sort((x, y) => y.SubjectID.CompareTo(x.SubjectID)); break;
                    case SortedBy.Title: notes.Sort((x, y) => x.Name.CompareTo(y.Name)); break;
                    case SortedBy.TitleReverse: notes.Sort((x, y) => y.Name.CompareTo(x.Name)); break;
                }
            }
        }
    }
}
