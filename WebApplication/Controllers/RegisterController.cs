using System.Diagnostics;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplication.Models;
using Model;
using Services.AccountService;

namespace WebApplication.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        private readonly IHostEnvironment _host;
        public RegisterController(IMapper mapper, IAccountService accountService, IHostEnvironment host)
        {
            _host=host;
            _mapper=mapper;
            _service = accountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            RegisterModel model = new RegisterModel();
            model.groupList = (_service.getGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Person user = await _service.LoadPersonAsync(model.Username);
                if (user == null)
                {
                    Person newPerson = new Person{Name=model.Name,Surname = model.Surname, Username = model.Username, Password = model.Password};
                    Student newStudent = new Student{Person = newPerson,TicketNumber=model.TicketNumber,ReportCard=model.ReportCard,GroupID=model.Group};
                    await _service.CreateStudentAsync(newStudent);
 
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect data");
            }
            model.groupList = (_service.getGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            return View("Index",model);
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