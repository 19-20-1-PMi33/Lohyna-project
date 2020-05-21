using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Core.DTO;
using Microsoft.Extensions.Hosting;
using Services.NotesService;
using Services.ProfileService;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesService notes;
        private readonly IProfileService profile;

        public NotesController(INotesService _notes, IProfileService _profile)
        {
            notes = _notes;
            profile = _profile;
        }

        public async Task<IActionResult> Index(int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 2;
            
            IList<Model.Note> notesList = notes.LoadNotesAsync(User.Identity.Name).Result.ToList();

            notesList = sortOrder switch
            {
                SortState.NameDesc => notesList.OrderByDescending(x => x.Name).ToList(),
                SortState.NameAsc => notesList.OrderBy(x => x.Name).ToList(),
                
                SortState.CreatedDesc => notesList.OrderByDescending(x => x.Created).ToList(),
                SortState.CreatedAsc => notesList.OrderBy(x => x.Created).ToList(),
                
                SortState.DeadlineDesc => notesList.OrderByDescending(x => x.Deadline).ToList(),
                SortState.DeadlineAsc=> notesList.OrderBy(x => x.Deadline).ToList(),
                
                _ =>  notesList.OrderBy(x => x.Name).ToList(),
            };
            var count = notesList.Count();
            var items = notesList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
            IndexNotesViewModal notesViewModal = new IndexNotesViewModal
            {
                NotesPaginationViewModal = new NotesPaginationViewModal(count, page, pageSize),
                SortNotesViewModal = new SortNotesViewModal(sortOrder),
                Notes = items
            };
 
            return View("Notes", notesViewModal);
        }
        
        public async Task<IActionResult> Edit(string Name)
        {
            var res = notes.LoadNotesAsync(User.Identity.Name).Result.FirstOrDefault(n => n.Name == Name);
            ViewData["subjectsList"] = (notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList();            
            return View("Edit", res);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["subjectsList"] = (notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList();            
            return View ("Edit", new Model.Note());
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Model.Note note)
        {
            if(ModelState.IsValid)
            {
                if(notes.LoadNotesAsync(User.Identity.Name).Result.FirstOrDefault(n => n.Name == note.Name) != null)
                {
                    notes.DeleteNoteAsync(notes.LoadNotesAsync(User.Identity.Name).Result.FirstOrDefault(n => n.Name == note.Name));
                    await notes.CreateNoteAsync(note);
                }
                else
                {
                    await notes.CreateNoteAsync(note);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", note);
            }
        }
        
        public async Task<IActionResult> Delete(string Name)
        {
            ViewBag.NoteToDelete = Name;
            return View("Delete");
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}