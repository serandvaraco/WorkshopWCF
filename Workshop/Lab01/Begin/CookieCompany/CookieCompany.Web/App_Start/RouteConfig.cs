using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CookieCompany.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name:"productIdJson",
                 url: "pjson/{id}",
                 defaults: new {controller = "utils", action= "GetProductsById" }
                );

            routes.MapRoute(
               name: "productsJson",
               url: "pjson",
               defaults: new { controller = "utils", action = "GetProducts" }
              );

            routes.MapRoute(
                name: "ProductDetail",
                url: "p/{id}",
                defaults: new
                {
                    controller = "Products",
                    action = "Details"
                },
                constraints: new
                {
                    id = "[0-9]+"
                });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults:
                new
                {
                    controller = "Products",
                    action = "Index",
                    id = UrlParameter.Optional
                });

            
        }
    }
}
