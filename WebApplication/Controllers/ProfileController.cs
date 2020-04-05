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
            Core.DTO.PersonType userType = _profile.PersonTypeAsync("username").Result;
            ProfileViewModel model = new ProfileViewModel{
                Username = "username"
            };
            if(userType == Core.DTO.PersonType.student){
                Core.DTO.Student studentData = _profile.LoadPersonAsync("username").Result as Core.DTO.Student;
                model.Name  = studentData.Name;
                model.Surname = studentData.Surname;
                model.Photo = studentData.Photo;
                model.Faculty = studentData.Faculty;
                model.Group = studentData.GroupID;
            }
            else{
                
            }
            return View("Profile", model);
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