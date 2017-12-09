using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using WebApp.Core.Services;
using WebApp.Repositories;

namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IAlertsRepository, AlertsRepository>();
            container.RegisterType<ISourcesRepository, SourcesRepository>();
            container.RegisterType<IAlertsService, AlertsService>();
            container.RegisterType<ICourseRepository, CourseRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}