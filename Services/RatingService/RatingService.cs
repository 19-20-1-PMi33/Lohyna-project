using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO;
using Model;
using AutoMapper;
using Repositories.UnitOfWork;

namespace Services.RatingService
{
    public class RatingService: IRatingService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapRatings;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapRatings)
        {
            _unitOfWork = unitOfWork;
            _mapRatings = mapRatings;
        }

        public Task<List<Model.Rating>> LoadRatingAsync(Model.Student student)
        {
            var ratingsList = _unitOfWork.Marks.LoadMarksAsync(student);
            return ratingsList;
        }
    }
}