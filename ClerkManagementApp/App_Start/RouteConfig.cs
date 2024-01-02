using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using ClerkManagementApp.DAL.Interfaces;
using ClerkManagementApp.DAL.Services;
using Unity;
using Unity.AspNet.Mvc;

namespace ClerkManagementApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            var container = new UnityContainer();

            // Register your dependencies, including IExpenseService
            container.RegisterType<IClerkService, ClerkService>();
            container.RegisterType<IClerkRepository, ClerkRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
