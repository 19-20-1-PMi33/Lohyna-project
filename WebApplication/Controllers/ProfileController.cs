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

        private readonly IMapper _personMapper;
        private readonly IProfileService _profile;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IMapper mapper, IProfileService profile, ILogger<ProfileController> logger)
        {
            _mapper = mapper;
            _personMapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Core.DTO.Student, Models.ProfileViewModel>();
                cfg.CreateMap<Core.DTO.Lecturer, Models.ProfileViewModel>();
            }));
            _profile = profile;
            _logger = logger;
        }

        public IActionResult Index()
        {
            string username = "username";
            Core.DTO.Person userData = _profile.LoadPersonAsync(username).Result;
            ProfileViewModel model;
            if(userData.personType == Core.DTO.PersonType.student){
                model = _personMapper.Map<ProfileViewModel>(userData as Core.DTO.Student);
            }
            else{
                model = _personMapper.Map<ProfileViewModel>(userData as Core.DTO.Lecturer);
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