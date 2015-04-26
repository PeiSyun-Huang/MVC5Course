using MVC5Course.Models;
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

        // 簡單模型繫結
        public ActionResult Simple1()
        {
            return View();
        }

        // 傳入的變數名稱等同於欄位名稱(無論大小寫)，模組繫結會自動判斷
        [HttpPost]
        public ActionResult Simple1(string Username, string Password)
        {
            return Content("Simple1:" + Username + " / " + Password);
        }

        public ActionResult Simple2()
        {
            return View("Simple1");
        }

        [HttpPost]
        public ActionResult Simple2(FormCollection form)
        {
            return Content("Simple2:" + form["Username"] + " / " + form["Password"]);
        }

        // 複雜模型繫結
        public ActionResult Complex1()
        {
            return View("Simple1");
        }

        // 單一表單直接傳入，無需理會變數名稱
        [HttpPost]
        public ActionResult Complex1(Simple1ViewModel item)
        {
            return Content("Complex1:" + item.Username + " / " + item.Password);
        }

        public ActionResult Complex2()
        {
            return View();
        }

        // 如果想同時送出多個表單同名欄位，需額外設定各欄位的name
        // 以此例子來說，各欄位前面需加前輟詞(Prefix) item1 / item2 (根據傳入的變數名稱)
        // 讓模組繫結知道屬於哪一個表單的欄位
        [HttpPost]
        public ActionResult Complex2(Simple1ViewModel item1, Simple1ViewModel item2)
        {
            return Content("Complex2:" + item1.Username + " / " + item1.Password + "<br/>" + item2.Username + " / " + item2.Password);
        }
    }
}