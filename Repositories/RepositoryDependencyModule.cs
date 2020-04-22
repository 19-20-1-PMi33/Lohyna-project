using Autofac;
using Repositories.UnitOfWork;

namespace Repositories
{
    public class RepositoryDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>();
        }
    }
}