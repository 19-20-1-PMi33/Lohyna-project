using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.NewsFeedService;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INewsFeedService _newsFeed;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IMapper mapper, INewsFeedService newsFeed, ILogger<HomeController> logger)
        {
            _mapper = mapper;
            _newsFeed = newsFeed;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}