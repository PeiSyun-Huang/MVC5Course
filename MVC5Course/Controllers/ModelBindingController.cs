using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ModelBindingController : BaseController
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            ViewData.Model = db.Product.Find(100);

            // ViewData["Product"] == ViewBag.Product
            ViewData["Product"] = db.Product.Find(50);

            return View();
        }

        public ActionResult TempData1()
        {
            // 只存在於單一Action
            ViewData["Message1"] = "Hello World1";

            // 可跨Action
            // 讀取後即刪除，未讀取會一直保留到網站重啟或被讀取時
            TempData["Message2"] = "Hello World2";

            // 可跨Action
            Session["Message3"] = "Hello World3";

            return RedirectToAction("TempData2");
        }

        public ActionResult TempData2()
        {
            // 因為轉址的關係，此訊息不存在。
            ViewData["Message1"] = ViewData["Message1"];

            // 第一次進來可看到訊息，F5後訊息消失
            ViewData["Message2"] = TempData["Message2"];

            // 無論進來幾次都會出現訊息
            ViewData["Message3"] = Session["Message3"];
            return View();
        }
    }
}