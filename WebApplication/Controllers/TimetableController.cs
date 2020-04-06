using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.TimeTableService;
using WebApplication.Models;
using System.Linq;
using System;

public enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
}

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
            List<Core.DTO.Timetable> ls = _timeTable.LoadTimetableAsync().Result;
            keyValues = ls.GroupBy(x => x.TimeID)
                .ToDictionary(x => x.Key, x => x.OrderBy(x => (int)((WeekDays)Enum.Parse(typeof(WeekDays), x.Day))).ToList());
            keyValues = keyValues.OrderBy(k => k.Key).ToDictionary(z => z.Key, y => y.Value);

            foreach(var i in keyValues.Values)
            {
                adjustTimetableItems(i);
            }
            
            return View("Timetable", keyValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void adjustTimetableItems(List<Core.DTO.Timetable> timetables)
        {
            for (int j = 0; j < timetables.Count; ++j)
            {
                if ((int)((WeekDays)Enum.Parse(typeof(WeekDays), timetables[j].Day)) != j)
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