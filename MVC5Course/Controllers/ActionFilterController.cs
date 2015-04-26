using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ActionFilterController : Controller
    {
        // GET: ActionFilter
        public ActionResult Index()
        {
            return View();
        }

        [HandleError(Master = "", ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        public ActionResult MadeMeWrong(string type = "")
        {
            if (type == "1")
            {
                throw new ArgumentException("ErrorArgument");
            }
            throw new Exception("Error");
        }
    }
}