using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

<<<<<<< HEAD
<<<<<<< HEAD:CaelumEstoque/CaelumEstoque/App_Start/RouteConfig.cs
namespace CaelumEstoque
=======
namespace aspMVC
>>>>>>> 28c2e130f131034394ebcfae7f05736d6731573d:aspMVC/App_Start/RouteConfig.cs
=======
namespace CaelumEstoque
>>>>>>> 28c2e130f131034394ebcfae7f05736d6731573d
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
