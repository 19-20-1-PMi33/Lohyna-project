using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.TimeTableService;
using WebApplication.Models;

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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}