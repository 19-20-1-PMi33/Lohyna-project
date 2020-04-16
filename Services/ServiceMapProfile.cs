using AutoMapper;

namespace Services
{
    public class ServiceMapProfile: Profile
    {
        public ServiceMapProfile()
        {
            CreateMap<Model.News, Core.DTO.News>();
            CreateMap<Model.Person, Core.DTO.Person>();
            CreateMap<Model.Student,Core.DTO.Student>();
            CreateMap<Model.Lecturer,Core.DTO.Lecturer>();
            CreateMap<Model.Timetable, Core.DTO.Timetable>();
        }
    }
}