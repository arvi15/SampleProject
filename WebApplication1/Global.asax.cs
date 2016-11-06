using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApplication1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            BundleConfig.RegisterBundles(new System.Web.Optimization.BundleCollection() );


            RouteConfig.RegisterRoutes(RouteTable.Routes);
           
        }
    }
}