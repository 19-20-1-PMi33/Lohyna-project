using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.TimeTableService;
using WebApplication.Models;
using System.Linq;
using System;

namespace WebApplication.Controllers
{
    public class TimetableController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITimeTableService _timeTable;
        private readonly ILogger<TimetableController> _logger;

        public TimetableController(IMapper mapper, ITimeTableService timeTable, ILogger<TimetableController> logger)
        {
            _mapper = mapper;
            _timeTable = timeTable;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Dictionary<int, List<Core.DTO.Timetable>> keyValues;
            Dictionary<string, int> daysOfWeek = new Dictionary<string, int>()
            {
                ["Monday"] = 0,
                ["Tuesday"] = 1,
                ["Wednesday"] = 2,
                ["Thursday"] = 3,
                ["Friday"] = 4
            };
            List<Core.DTO.Timetable> ls = _timeTable.LoadTimetableAsync().Result;
            keyValues = ls.GroupBy(x => x.TimeID)
                .ToDictionary(x => x.Key, x => x.OrderBy(x => daysOfWeek[x.Day]).ToList());
            keyValues = keyValues.OrderBy(k => k.Key).ToDictionary(z => z.Key, y => y.Value);

            foreach(var i in keyValues.Values)
            {
                adjustTimetableItems(i, daysOfWeek);
            }
            
            return View("Timetable", keyValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void adjustTimetableItems(List<Core.DTO.Timetable> timetables, Dictionary<string, int> daysOfWeek)
        {
            for (int j = 0; j < timetables.Count; ++j)
            {
                if (daysOfWeek[timetables[j].Day] != j)
                {
                    timetables.Insert(j, null);
                }
            }
            while (timetables.Count != 5)
            {
                timetables.Insert(timetables.Count, null);
            }
        }
    }
}