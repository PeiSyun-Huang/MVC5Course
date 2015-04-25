using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class JQueryController : Controller
    {
        // GET: JQuery
        public ActionResult Index()
        {
            return RedirectToAction("each");
        }

        public ActionResult each()
        {
            return View();
        }
    }
}