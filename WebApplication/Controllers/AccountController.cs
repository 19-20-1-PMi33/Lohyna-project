using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Model;
using Services.AccountService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Hosting;
 
namespace AuthApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAccountService _service;
        private readonly IHostEnvironment _host;
        public AccountController(IMapper mapper, AppDbContext context, IHostEnvironment host)
        {
            _host=host;
            _mapper=mapper;
            _service = new AccountService(context);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(HomeModel model)
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
            return View("Index",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(HomeModel model)
        {
            if (ModelState.IsValid)
            {
                Person user = await _service.LoadPersonAsync(model.Username);
                if (user == null)
                {
                    Person newPerson = new Person{Name=model.Name,Surname = model.Surname, Username = model.Username, Password = model.Password};
                    await _service.CreateStudentAsync(new Student{Person=newPerson,GroupID="Pmi-33"});
 
                    await Authenticate(model.Username);
 
                    return RedirectToAction("Index", "News");
                }
                else
                    ModelState.AddModelError("", "Incorrect data");
            }
            return View("Index",model);
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
    }
}