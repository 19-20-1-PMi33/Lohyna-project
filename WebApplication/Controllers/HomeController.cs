using System.Diagnostics;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime time = DateTime.Now;
            string photo = "news1.jpg";
            string title = "📢Лекція «Блокчейн: як працює біткоїн»";
            string text = "Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝\n🗓Теми лекції:\n👉 що таке блокчейн❓\n👉 як створюють біткоїн та як це працює❓\n⏰ 6 березня, з 16:30 – 18:00\n📍 ауд.270\n💫Реєстрація обов'язкова!👇";
            News n = new News(0,title,photo,text,time);
            List<News> l = new List<News>{n,n,n};
            NewsViewModel nw = new NewsViewModel{User="Roman",NewsFeed=l};
            return View(nw);
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