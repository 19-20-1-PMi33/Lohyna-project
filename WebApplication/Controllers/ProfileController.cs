using System.Diagnostics;
using AutoMapper;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.ProfileService;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProfileService _profile;
        private readonly ILogger<ProfileController> _logger;
        private readonly IHostEnvironment _host;

        public ProfileController(IMapper mapper, IProfileService profile, ILogger<ProfileController> logger, IHostEnvironment host)
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Model.Student, Models.ProfileViewModel>();
            }));
            _host=host;
            _profile = profile;
            _logger = logger;
        }
        public IActionResult Index()
        {
            Model.Student userData = _profile.LoadStudentAsync(User.Identity.Name).Result;
            ProfileViewModel model = _mapper.Map<ProfileViewModel>(userData);
            model.Person.Photo=ImageHelper.EncodeImage(_host.ContentRootPath+"/"+model.Person.Photo);
            model.FoundAt=_profile.GetAuditoryForStudent(userData);
            return View("Profile", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}