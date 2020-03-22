using Autofac;
using Repositories.UnitOfWork;

namespace DataServices
{
    public class RepositoryDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}