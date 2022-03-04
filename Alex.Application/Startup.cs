using System.Web.Http;
using Alex.BusinessLogic;
using FluentNHibernate.Cfg;
using Unity;
using NHibernate;
using Owin;
using Unity.WebApi;
using Unity.Injection;
using Unity.Lifetime;
using Alex.Model;
using Alex.Persistance.Repositories;
using Alex.Persistance.NHibernate.Repositories;
using Alex.Persistance.NHibernate;
using FluentNHibernate.Cfg.Db;

namespace Alex.Application
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //Configure Web API for self host
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
            config.Routes.MapHttpRoute(
              "DefaultApi",
              "api/{controller}/{action}/{id}",
              new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);

            IUnityContainer container = new UnityContainer();

            //register services
            container.RegisterType<IService, Service>();

            //register repositories
            container.RegisterType<IPersonRepository, PersonRepository>();

            container.RegisterType<ISession>(new PerResolveLifetimeManager(),
              new InjectionFactory(c =>
                c.Resolve<ISessionFactory>().OpenSession()
                ));

            container
              .RegisterType<ISessionFactory>(
                new ContainerControlledLifetimeManager(),
                  new InjectionFactory(c =>
                  {
                      var v = Fluently.Configure()
                                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(cc => cc.FromConnectionStringWithKey("config.connection.string.key")))
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PersonRepository>())
                                .BuildSessionFactory();
                     
                      return v;
                  })
                 );

            container.RegisterType<IUnitOfWork, NHibernateUnitOfWork>();

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}