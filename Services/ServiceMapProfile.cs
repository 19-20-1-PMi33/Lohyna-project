using System;
using AutoMapper;

namespace Services
{
    public class ServiceMapProfile: Profile
    {
        public ServiceMapProfile()
        {
            CreateMap<Model.News, Core.DTO.News>()
                .ForMember(dest => dest.TimePosted, 
                    opt => opt.MapFrom(src => DateTime.Parse(src.Time)))
                .ForMember(dest=>dest.Title,opt=>opt.MapFrom(src=>src.Name));
            CreateMap<Model.Timetable, Core.DTO.Timetable>();
            CreateMap<Model.Rating, Core.DTO.Rating>();
        }
    }
}