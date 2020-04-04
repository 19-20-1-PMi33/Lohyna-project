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
    Monday = 0,
    Tuesday = 1,
    Wednesday = 2,
    Thursday = 3,
    Friday = 4
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
                .ToDictionary(x => x.Key, x => x.OrderBy(x => (int)((WeekDays)Enum.Parse(typeof(WeekDays), x.Day))).ToList())
                ;
            keyValues = keyValues.OrderBy(k => k.Key).ToDictionary(z => z.Key, y => y.Value);

            foreach(var i in keyValues.Values)
            {

                for(int j = 0; j<i.Count; ++j)
                {
                    if ((int)((WeekDays)Enum.Parse(typeof(WeekDays), i[j].Day)) != j)
                    {
                        i.Insert(j, null);
                    }
                }
                while (i.Count != 5)
                {
                    i.Insert(i.Count, null);
                }
            }
            
            return View("Timetable", keyValues);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}