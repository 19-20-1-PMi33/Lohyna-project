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
using AutoMapper;

namespace WebApplication.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesService _notes;

        public NotesController(INotesService notes)
        {
            _notes = notes;
        }

        public IActionResult Index(int page = 1, SortState sortOrder = SortState.NameAsc)
        {
            const int pageSize = 3;
            
            IList<Model.Note> notesList = _notes.LoadNotesAsync(User.Identity.Name).Result.ToList();

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
            
            var notesViewModal = new IndexNotesViewModal
            {
                NotesPaginationViewModal = new NotesPaginationViewModal(count, page, pageSize),
                SortNotesViewModal = new SortNotesViewModal(sortOrder),
                Notes = items
            };
 
            return View("Notes", notesViewModal);
        }
        
        public IActionResult Edit([FromRoute] int id)
        {
            var res = _notes.LoadNotesAsync(User.Identity.Name).Result.Where(item=>item.Id==id).ToList();
            if(res.Count>0)
            {
                var subjectsList = (_notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList(); 
                subjectsList.Remove(res.First().SubjectID);
                ViewBag.subjectsList = subjectsList;  
                return View("Edit", res.First()); 
            }
            else
            {
                return RedirectToAction("Index");
            } 
        }

        public IActionResult Create()
        {
            ViewBag.subjectsList = (_notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList();            
            return View ("Create", new Model.Note());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Model.Note note)
        {
            if(ModelState.IsValid)
            {
                note.PersonID=User.Identity.Name;
                note.Created = DateTime.Now;
                await _notes.CreateNoteAsync(note);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", note);
            }
        }
        [HttpPost]
        public IActionResult Edit(Model.Note note)
        {
            if(ModelState.IsValid)
            {
                note.PersonID=User.Identity.Name;
                note.Created=DateTime.Now;
                _notes.UpdateNoteAsync(note);
                return RedirectToAction("Index");
            }
            else
            {
                var subjectsList = (_notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList(); 
                subjectsList.Remove(note.SubjectID);
                ViewBag.subjectsList = subjectsList;  
                return View("Edit", note);
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var res = _notes.LoadNotesAsync(User.Identity.Name).Result.Where(item=>item.Id==id).ToList();
            if(res.Count>0)
            {
                _notes.DeleteNoteAsync(res.First());
            }
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}