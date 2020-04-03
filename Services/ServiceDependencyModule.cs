using Autofac;
using Services.NewsFeedService;
using Services.TimeTableService;

namespace Services
{
    public class ServiceDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NewsFeedService.NewsFeedService>().As<INewsFeedService>();
            builder.RegisterType<TimeTableService.TimeTableService>().As<ITimeTableService>();
        }
    }
}