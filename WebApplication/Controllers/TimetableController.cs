using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.TimeTableService;
using Services.AccountService;
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
        private readonly IAccountService _service;
        private readonly IProfileService _profile;
        private readonly ILogger<TimetableController> _logger;

        public TimetableController(IMapper mapper, IAccountService service, ITimeTableService timeTable, IProfileService profile, ILogger<TimetableController> logger)
        {
            _mapper = mapper;
            _timeTable = timeTable;
            _profile = profile;
            _service = service;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var model =  _timeTable.LoadTimetableForGroupAsync(_profile.LoadStudentAsync(User.Identity.Name).GroupID);
            ViewBag.groupsList = (_service.GetGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            return View("Timetable",model);
        }
        
        [HttpPost]
        public IActionResult TimetableForGroup(string groupID)
        {
            var model =  _timeTable.LoadTimetableForGroupAsync(groupID);
            ViewBag.groupsList = (_service.GetGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            return View("Timetable",model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}