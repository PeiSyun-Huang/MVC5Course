using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    // 教學時順便安裝了一個套件 glimpse
    // 安裝教學網址 http://getglimpse.com/Docs/#download

    // 簡易安裝教學 套件管理器主控台

    // Step 1. Which web framework you using?
    // WebForms: PM> Install-Package Glimpse.WebForms
    // MVC: PM> Install-Package Glimpse.MVC5

    // Strp 2. What about Data Access?
    // Raw ADO: PM> Install-Package Glimpse.ADO
    // Entity Framework 6: PM> Install-Package Glimpse.EF6
    public class SharedDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 將原本要顯示的訊息，或執行內容，在此Action執行前先在此執行完畢後再呼叫Action顯示View
            filterContext.Controller.ViewBag.Message = "!! Your application description page.";
            base.OnActionExecuting(filterContext);
        }
    }
}