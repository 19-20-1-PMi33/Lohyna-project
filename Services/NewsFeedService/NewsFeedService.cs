using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Core;
using Core.DTO;
using Repositories.UnitOfWork;

namespace Services.NewsFeedService
{
    public class NewsFeedService : INewsFeedService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapProfile;

        public NewsFeedService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapProfile = mapper;
        }
        public async Task<List<News>> LoadNewsAsync()
        {
            var news = await _unitOfWork.NewsRepository.LoadAllNewsAsync();
            var newsDto = _mapProfile.Map<List<Core.DTO.News>>(news);
            return newsDto;
        }
    }
}