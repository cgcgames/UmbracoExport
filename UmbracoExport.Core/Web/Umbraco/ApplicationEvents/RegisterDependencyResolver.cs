using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Umbraco.Core;
using Umbraco.Web;
using UmbracoExport.Core.Services;
using UmbracoExport.Core.Services.Interfaces;

namespace UmbracoExport
{
    public class RegisterDependencyResolver : IApplicationEventHandler
    {
        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //setup IOC
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(RegisterDependencyResolver).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            builder.RegisterType<ExportService>().As<IExportService>();


            var container = builder.Build();

            var apiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = apiResolver;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //configure app insights
        }

        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            //throw new NotImplementedException();
        }
    }
}