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

        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CreatedSort"] = sortOrder == SortState.CreatedAsc ? SortState.CreatedDesc : SortState.CreatedAsc;
            ViewData["DeadlineSort"] = sortOrder == SortState.DeadlineAsc ? SortState.DeadlineDesc : SortState.DeadlineAsc;

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
            return View("Notes", notesList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}