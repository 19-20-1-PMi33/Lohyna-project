using Autofac;
using Services.NewsFeedService;
using Services.ProfileService;

namespace Services
{
    public class ServiceDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NewsFeedService.NewsFeedService>().As<INewsFeedService>();
            builder.RegisterType<ProfileService.ProfileService>().As<IProfileService>();
        }
    }
}