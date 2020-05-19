using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.TimeTableService;
using WebApplication.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Services.ProfileService;

namespace WebApplication.Controllers
{
    [Authorize]
    public class TimetableController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITimeTableService _timeTable;
        private readonly IProfileService _profile;
        private readonly ILogger<TimetableController> _logger;

        public TimetableController(IMapper mapper, ITimeTableService timeTable, IProfileService profile, ILogger<TimetableController> logger)
        {
            _mapper = mapper;
            _timeTable = timeTable;
            _profile = profile;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model =  _timeTable.LoadTimetableForGroupAsync(_profile.LoadStudentAsync(User.Identity.Name).Result.GroupID).Result;
            foreach (int i in model.Keys)
            {
                System.Console.WriteLine(i);
                foreach(var j in model[i]){
                    System.Console.WriteLine($"{j.Day}:{j.SubjectID}");
                }
            }
            return View("Timetable",model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}