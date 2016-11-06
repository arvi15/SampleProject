using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "empty",
            url: "",
            defaults: new { controller = "URLMappers", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
             name: "Filelist",
             url: "FileList/{action}/{id}",
             defaults: new { controller = "FileList", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
            name: "URLMappers",
            url: "URLMappers/{action}/{id}",
            defaults: new { controller = "URLMappers", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
                      name: "PNL",
                      url: "PNL/{action}/{id}",
                      defaults: new { controller = "PNL", action = "Index", id = UrlParameter.Optional }
                  );
            routes.MapRoute(
                    name: "Weather",
                    url: "Home/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Rewrite",
                url: "{name}",
                defaults: new { controller = "URLMappers", action = "Rewrite" }
            );
            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "PNL", action = "Index", id = UrlParameter.Optional }
                );

        }
    }
}

