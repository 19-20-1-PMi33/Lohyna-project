using AutoMapper;

namespace Services
{
    public class ServiceMapProfile: Profile
    {
        public ServiceMapProfile()
        {
            CreateMap<Model.News, Core.DTO.News>();
        }
    }
}