using Autofac;
using Services.NewsFeedService;
using Services.ProfileService;
using Services.TimeTableService;

namespace Services
{
    public class ServiceDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NewsFeedService.NewsFeedService>().As<INewsFeedService>();
            builder.RegisterType<ProfileService.ProfileService>().As<IProfileService>();
            builder.RegisterType<TimeTableService.TimeTableService>().As<ITimeTableService>();
        }
    }
}