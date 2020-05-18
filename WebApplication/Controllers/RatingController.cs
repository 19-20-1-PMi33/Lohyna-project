using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Services.RatingService;
using Services.ProfileService;
using WebApplication.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class RatingController: Controller
    {
        private readonly IRatingService _rating;
        private readonly IProfileService _profile;

        public RatingController(IRatingService rating, IProfileService profile)
        {
            _rating = rating;
            _profile = profile;
        }
        public IActionResult Index()
        {
            Model.Student userData = _profile.LoadStudentAsync(User.Identity.Name).Result;
            List<Model.Rating> ratingsList = _rating.LoadRatingAsync(userData).Result;
            return View("Rating", ratingsList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}