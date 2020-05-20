using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class AdminController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Photo = "/images/user.png";
			ViewBag.Name = "Oleh";
			ViewBag.Role = "admin";
			ViewBag.NumberOfStudents = 120;
			ViewBag.NumberOfSubjects = 120;
			ViewBag.NumberOfNews = 120;
			ViewBag.NumberOfLectors = 120;
			return View();
		}
		public ActionResult AdminStudent()
		{
			return View();
		}
	}
}
