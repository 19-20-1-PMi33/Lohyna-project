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
                    opt => opt.MapFrom(src => DateTime.Parse(src.Time)));
            CreateMap<Model.Person, Core.DTO.Person>();
            CreateMap<Model.Student,Core.DTO.Student>();
            CreateMap<Model.Lecturer,Core.DTO.Lecturer>();
            CreateMap<Model.Timetable, Core.DTO.Timetable>();
            CreateMap<Model.Rating, Core.DTO.Rating>();
        }
    }
}