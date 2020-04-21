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
        private readonly IMapper _mapper;
        private readonly IRatingService _rating;
        private readonly ILogger<RatingController> _logger;

        public RatingController(IMapper mapper, IRatingService rating, ILogger<RatingController> logger)
        {
            _mapper = mapper;
            _rating = rating;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Core.DTO.Rating> ratingsList = _rating.LoadRatingAsync().Result;
            return (View("Rating", ratingsList));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}