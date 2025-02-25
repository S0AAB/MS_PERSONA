using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using MS_PERSONA.Interfaces;
using MS_PERSONA.Repositories;
using MS_PERSONA.Services;
using MS_PERSONA.Models;

public class AutofacConfig
{
    public static void Register()
    {
        var builder = new ContainerBuilder();

        //Registro del contexto
        builder.RegisterType<PersonasDBEntities>().InstancePerLifetimeScope();

        // Registrar Repositorio y Servicio
        builder.RegisterType<PersonaRepository>().As<IPersonaRepository>().InstancePerRequest();
        builder.RegisterType<PersonaService>().As<IPersonaService>().InstancePerRequest();

        // Configurar Web API
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        var container = builder.Build();
        GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
}