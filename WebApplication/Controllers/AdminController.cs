using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Model;
using Services.ProfileService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Core.Helpers;

namespace WebApplication.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private readonly IMapper mapper;
		private readonly IProfileService profile;
		private readonly IHostEnvironment host;
		public AdminController(IProfileService _profile, IHostEnvironment _host)
		{
			profile = _profile;
			host = _host;
			mapper = new Mapper(new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Model.Student, Models.ProfileViewModel>();
			}));
		}
		public void getInformation()
		{
			Student userData = profile.LoadStudentAsync(User.Identity.Name).Result;
			ProfileViewModel model = mapper.Map<ProfileViewModel>(userData);
			ViewBag.Photo = ImageHelper.EncodeImage(host.ContentRootPath + "/" + model.Person.Photo);

			ViewBag.Name = userData.Person.Name + " " + userData.Person.Surname;

			ViewBag.Role = "admin";
			ViewBag.NumberOfSubjects = 120;
			ViewBag.NumberOfNews = 120;
			ViewBag.NumberOfLectors = 120;

			List<string> usernames = new List<string>(){ "petro" , "roman", "oleg", "nikita"};
			ViewBag.Students = new List<Student>();
			foreach(var username in usernames)
				ViewBag.Students.Add(profile.LoadStudentAsync(username).Result);
			ViewBag.NumberOfStudents = ViewBag.Students.Count;
		}
		public ActionResult Index()
		{
			getInformation();
			return View();
		}
		public ActionResult AdminStudent()
		{
			getInformation();
			return View("AdminStudent", ViewBag.Students);
		}
	}
}
