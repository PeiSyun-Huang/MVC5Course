using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // 本機 檔案路徑
        public ActionResult File1()
        {
            return File(Server.MapPath("~/App_Data/logo11w.png"), "image/png");
        }

        // URL 檔案路徑
        public ActionResult File2()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            return File(data, "image/png");
        }

        // URL 檔案路徑 強迫下載並存成指定檔案名稱
        public ActionResult File3()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            return File(data, "image/png","Google.png");
        }

        // URL 檔案路徑 強迫下載並存成指定檔案名稱，需輸入參數 url / fileNamn
        // 參數直接加在網址後面，url / fileName 有預設值
        public ActionResult File4(string url = "https://www.google.com.tw/images/srpr/logo11w.png", string fileName = "Google.png")
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            return File(data, "image/png", fileName);
        }

        // 輸出HTML
        public ActionResult File5()
        {
            return File(Server.MapPath("~/Content/File5.html"),"text/html");
        }

        // 輸出Text
        public ActionResult File6()
        {
            return File(Server.MapPath("~/Content/File5.html"), "text/plain");
        }

        // 輸出中文檔名
        public ActionResult GetChineseFile()
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData("https://www.google.com.tw/images/srpr/logo11w.png");
            if (Request.Browser.Browser == "IE" && Convert.ToInt32(Request.Browser.MajorVersion) < 9)
            {
                // 舊版 IE 使用舊的相容性 作法
                return File(data, "image/png", Server.UrlPathEncode("谷哥.png"));
            }
            else
            {
                // 新版瀏覽器使用 RFC2231 規範的 Header Value 做法
                return File(data, "image/png", "谷哥.png");
            }
        }
    }
}