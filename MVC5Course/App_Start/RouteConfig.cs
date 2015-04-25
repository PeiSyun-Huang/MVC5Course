using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Course
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "General",
                url: "{controller}.{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //, 
                //// id 限制為數字，目前有問題，無論怎麼點選都是同一頁。
                //constraints: new {
                //    id = @"\d+"
                //}
            );

            // 使上面對應不到後，可以讀到首頁。
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
