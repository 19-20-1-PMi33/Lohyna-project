using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.RatingService;
using WebApplication.Models;
using System.Linq;
using System;

namespace WebApplication.Controllers
{
    public class RatingController: Controller
    {
        private readonly IRatingService _rating;

        public RatingController(IRatingService rating)
        {
            _rating = rating;
        }
        public IActionResult Index()
        {
            List<Core.DTO.Rating> ratingsList = _rating.LoadRatingAsync().Result;
            return View("Rating", ratingsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}