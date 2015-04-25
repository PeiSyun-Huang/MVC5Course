using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ActionResultController : Controller
    {
        // GET: ActionResult
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View1()
        {
            return PartialView("View2");
        }

        public ActionResult View2()
        {
            return Content("<script>alert('OK!')</script>", "text/html");
        }

        public ActionResult SharedView()
        {
            return View("SharedView");
        }
    }
}