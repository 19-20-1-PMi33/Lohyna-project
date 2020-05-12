﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.NewsFeedService;
using WebApplication.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Model;
using Services.AccountService;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        private readonly INewsFeedService _newsFeed;
        private readonly IHostEnvironment _host;
        public HomeController(IMapper mapper, INewsFeedService newsService, IAccountService accountService, IHostEnvironment host)
        {
            _host=host;
            _mapper=mapper;
            _service = accountService;
            _newsFeed = newsService;
        }
        public async Task<IActionResult> Index()
        {
            var news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : $"data:image/jpeg;base64,{ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)}"
                ));
            return View(new LogInModel{news = news});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInModel model)
        {
            if (ModelState.IsValid)
            {
                Person user = await _service.LoadPersonAsync(model.Username);
                if (user != null && user.Password == model.Password)
                {
                    await Authenticate(model.Username);
 
                    return RedirectToAction("Index", "News");
                }
                ModelState.AddModelError("", "Incorrect data");
            }
            model.news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : $"data:image/jpeg;base64,{ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)}"
                ));
            return View("Index",model);
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
                    Student newStudent = new Student{Person = newPerson,TicketNumber=2,ReportCard=2,GroupID="PMi-33"};
                    await _service.CreateStudentAsync(newStudent);
                    await Authenticate(model.Username);
 
                    return RedirectToAction("Index", "News");
                }
                else
                    ModelState.AddModelError("", "Incorrect data");
            }
            return View("Register",model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
 
        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
 
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Index");
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