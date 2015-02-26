using System.Reflection;
using Autofac;

namespace StatTrackr.WebApi.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("StatTrackr.Data"))
                 .Where(t => t.Name.EndsWith("Repository"))
                 .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
