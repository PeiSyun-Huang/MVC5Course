using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ActionResultController : BaseController
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

        public ActionResult RunJaveScriptView()
        {
            return View();
        }

        public ActionResult RunJavaScript()
        {
            return JavaScript("alert('JS OK!')");
        }

        public ActionResult Json1()
        {
            // 因為導覽屬性的關係，會導致循環參考(無限迴圈)，故將此延遲載入關閉，當讀取到導覽屬性時，會變成null，則不會造成循環參考。
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(10);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JQueryToGetJsonData()
        {
            return View();
        }


        // 以下轉址若為一個網站的新舊網址來說，永久轉址較好，因為會繼承原Google已經打好的分數，而不是重新打分數。

        /* HTTP 狀態碼
            1xx - 參考資訊(Informational)。
            2xx - 成功(OK)：一般最常見的HTTP狀態碼如200代表OK，也就是網頁正常回應的意思，
            201代表Created代表伺服器端已經成功建立資源。
            3xx - 重新導向(Redirection)：剛剛看過的302代表Found，意即找到這個資源，但暫時
            移到另一個URL，而301則代表Moved Permanently，意即URL已經發生永久改變，用戶
            端必須轉向到另一個URL，且不用保留原本URL的紀錄。
            4xx - 用戶端錯誤(Client Error)：這裡最常見的就是404 Not Found，代表找不到網頁，
            還有401 Unauthorized，代表拒絕存取也都是非常常見的用戶端錯誤。
            5xx - 伺服器錯誤(Server Error)：當伺服器發生錯誤時會回應5xx的狀態碼，而500
            Internal Server Error屬內部伺服器錯誤，也是經常看見的HTTP狀態碼。
        */

        // 暫時轉址，HTTP狀態碼為302，暫時轉址會讓Google對網頁重新打分數
        public ActionResult Redirect1()
        {
            return Redirect("http://tw.yahoo.com");
        }

        // 暫時轉址，HTTP狀態碼為302，暫時轉址會讓Google對網頁重新打分數
        public ActionResult Redirect2()
        {
            return Redirect("/Home/About");
        }

        // 永久轉址，HTTP狀態碼為301，永久轉址會讓Google對網頁打的分數繼承至新網頁
        // 永久轉址會讓Google知道網站要換新網址，會重新建立索引，讓新網址可以繼承之前的分數被搜尋到
        public ActionResult Redirect3()
        {
            return RedirectPermanent("http://tw.yahoo.com");
        }
    }
}