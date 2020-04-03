using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.ProfileService;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProfileService _profile;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IMapper mapper, IProfileService profile, ILogger<ProfileController> logger)
        {
            _mapper = mapper;
            _profile = profile;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Profile", new ProfileViewModel() { Username = "user", Surname = " ", Photo = " ", PersonType = PersonType.student, Faculty = " ", Group = "PMI-33", Name = " " });

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