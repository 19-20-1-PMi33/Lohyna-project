using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            IList<Model.Note> notesList = notes.LoadNotesAsync(User.Identity.Name).Result;
            return View("Notes", notesList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}