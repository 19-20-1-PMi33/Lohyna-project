using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.NewsFeedService;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private IHostEnvironment _host;
        private readonly INewsFeedService _newsFeed;

        public NewsController(INewsFeedService newsFeed, IHostEnvironment host)
        {
            _host = host;
            _newsFeed = newsFeed;
        }
        
        public IActionResult Index()
        {
            var news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)
                ));
            return View(news);
        }

        
        [HttpPost]
        public IActionResult FilterNewsByDate(string startDate, string endDate)
        {
            var news = _newsFeed
            .LoadNewsAsync()
            .Result
            .Where(n => n.TimePosted >= DateTime.Parse(startDate) && n.TimePosted<=DateTime.Parse(endDate))
            .Select(x => (x,
                    x.Photo is null
                        ? ""
                        : ImageHelper.EncodeImage(_host.ContentRootPath + "/" + x.Photo)
                ));
            return View("Index", news);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}