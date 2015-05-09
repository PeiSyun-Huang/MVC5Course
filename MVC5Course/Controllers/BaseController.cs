using MVC5Course.ActionFilters;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    // 將 Base 控制器設定自訂ActionFilter的Logger屬性，讓所有繼承此控制器的控制器擁有Logger功能
    [Logger]
    // 宣告一個 abstract 類別，使得 BaseController 無法被 MVC 叫用
    public abstract class BaseController : Controller
    {
        protected ApplicationSignInManager _signInManager;
        protected ApplicationUserManager _userManager;

        protected FabricsEntities db = new FabricsEntities();

        protected ClientRepository repoClient = RepositoryHelper.GetClientRepository();

        protected OccupationRepository repoOccupation = RepositoryHelper.GetOccupationRepository();

#if DEBUG
        public ActionResult Debug()
        {
            return View();
        }
#endif
    }
}