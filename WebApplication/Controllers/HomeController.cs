using System;
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
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [AllowAnonymous]
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
            if(!String.IsNullOrEmpty(User.Identity.Name))
                return RedirectToAction("Index","News");
            var news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)
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
                if (user == null)
                    ModelState.AddModelError("", "User not found");
                else if (user.Password != AccountHelper.ComputeSha256Hash(model.Password))
                    ModelState.AddModelError("", "Passwrod incorrect");
                else{
                    await Authenticate(model.Username);
                    return RedirectToAction("Index", "News");
                }

            }
            model.news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)
                ));
            return View("Index",model);
        }
        public async Task Authenticate(string userName)
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