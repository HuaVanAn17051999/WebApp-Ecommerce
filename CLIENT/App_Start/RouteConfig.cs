using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CLIENT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "ProductGetById",
             url: "dtdd/{seotitle}/{id}",
             defaults: new { controller = "Product", action = "ProductGetById", id = UrlParameter.Optional },
             new string[] { "CLIENT.Controllers" }
             );
            routes.MapRoute(
           name: "ProductDetails",
           url: "chi-tiet-san-pham/{seotitle}/{id}",
           defaults: new { controller = "Product", action = "ProductDetails", id = UrlParameter.Optional },
           new string[] { "CLIENT.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "CLIENT.Controllers" }
            );
        }
    }
}
