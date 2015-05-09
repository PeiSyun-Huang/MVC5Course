using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    public class LoggerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sActionName = filterContext.ActionDescriptor.ActionName;
            Trace.TraceInformation(sActionName + " Logger Start.");
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string sActionName = filterContext.ActionDescriptor.ActionName;
            Trace.TraceInformation(sActionName + " Logger End.");
            base.OnActionExecuted(filterContext);
        }
    }
}