using Autofac;
using Services.NewsFeedService;

namespace Services
{
    public class ServiceDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NewsFeedService.NewsFeedService>().As<INewsFeedService>();
        }
    }
}