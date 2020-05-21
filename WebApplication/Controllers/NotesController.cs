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
        private readonly INotesService notes;
        private readonly IProfileService profile;
        private readonly IMapper _mapper;

        public NotesController(INotesService _notes, IProfileService _profile, IMapper mapper)
        {
            notes = _notes;
            profile = _profile;
            _mapper = mapper;
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
        
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var res = notes.LoadNotesAsync(User.Identity.Name).Result.Where(item=>item.Id==id).ToList();
            if(res.Count>0)
            {
                var subjectsList = (notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList(); 
                subjectsList.Remove(res.First().SubjectID);
                ViewBag.subjectsList = subjectsList;  
                return View("Edit", res.First()); 
            }
            else
            {
                return RedirectToAction("Index");
            } 
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.subjectsList = (notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList();            
            return View ("Create", new Model.Note());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Model.Note note)
        {
            if(ModelState.IsValid)
            {
                note.PersonID=User.Identity.Name;
                note.Created = DateTime.Now;
                await notes.CreateNoteAsync(note);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", note);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Model.Note note)
        {
            if(ModelState.IsValid)
            {
                note.PersonID=User.Identity.Name;
                note.Created=DateTime.Now;
                notes.UpdateNoteAsync(note);
                return RedirectToAction("Index");
            }
            else
            {
                var subjectsList = (notes.LoadSubjectsAsync().Result as List<Model.Subject>).Select(subject => subject.Name).ToList(); 
                subjectsList.Remove(note.SubjectID);
                ViewBag.subjectsList = subjectsList;  
                return View("Edit", note);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = notes.LoadNotesAsync(User.Identity.Name).Result.Where(item=>item.Id==id).ToList();
            if(res.Count>0)
            {
                notes.DeleteNoteAsync(res.First());
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