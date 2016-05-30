using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using Contacts.Domain.Entities;
using System.Web.Mvc;
using Contacts.WebUI.Infrastructure;
using System.Net.Http.Formatting;

using Ninject;
using Contacts.Domain.Absract;
using Contacts.Domain.Concrete;

namespace Contacts.WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {           
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var kernel = new StandardKernel();
            kernel.Bind<IContactRepository>().To<EFContactRepository>();
            config.DependencyResolver = new NinjectResolver(kernel);
                   
        }
    }
}
