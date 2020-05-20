using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using Model;

namespace WebApplication.Controllers
{
	public class AdminController : Controller
	{
		public void getInformation()
		{
			ViewBag.Photo = "/images/user.png";
			ViewBag.Name = "Oleh";

			ViewBag.Role = "admin";
			ViewBag.NumberOfSubjects = 120;
			ViewBag.NumberOfNews = 120;
			ViewBag.NumberOfLectors = 120;

			ViewBag.Students = new List<Student>();
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
