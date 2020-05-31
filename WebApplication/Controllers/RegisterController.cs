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
using System.IO;
using Core.Helpers;
using System;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [AllowAnonymous]
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
            model.groupList = (_service.GetGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            model.facultyList = _service.GetFacultyListAsync() as List<string>;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _service.LoadPersonAsync(model.Username);
                if (user == null)
                {
                    string imageSavingPath = "../UploadedFiles/";
                    Person newPerson = new Person{Name=model.Name,Surname = model.Surname, Username = model.Username, Password = model.Password};
                    newPerson.Password=AccountHelper.ComputeSha256Hash(newPerson.Password);
                    if(model.Photo==null || !model.Photo.ContentType.ToLower().Contains("image")){
                        newPerson.Photo="DbResources/Profile/profile_placeholder.jpg";
                    }
                    else{
                        string path = imageSavingPath + model.Photo.FileName;
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await model.Photo.CopyToAsync(fileStream);
                        }
                        newPerson.Photo=path;
                    }
                    Student newStudent = new Student{Person = newPerson,TicketNumber=model.TicketNumber,ReportCard=model.ReportCard,GroupID=model.Group};
                    await _service.CreateStudentAsync(newStudent);
 
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect data");
            }
            model.groupList = (_service.GetGroupListAsync().Result as List<Model.Group>).Select(group=>group.Name).ToList();
            model.facultyList = _service.GetFacultyListAsync() as List<string>;
            return View("Index",model);
        }
    }
}