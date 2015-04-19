using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class CRUDController : Controller
    {
        FabricsEntities db = new FabricsEntities();
        // GET: CRUD
        public ActionResult Index()
        {
            //var data = db.Product.Where(p => p.ProductName.StartsWith("c") && p.Price <= 10 && p.Price >= 5);

            var data = db.Product.Where(p => p.ProductName.StartsWith("c"));

            return View(data);
        }

        // GET: CRUD/Details/5
        public ActionResult Details(int id)
        {
            // 只能放PK
            Product data = db.Product.Find(id);

            //// 因為可能此方法是找清單回來，故只能用first取一個
            //Product one = db.Product.Where(p => p.ProductId == id).First();

            //// 直接取第一個，若無資料會丟例外
            //Product one2 = db.Product.First(p => p.ProductId == id);
            //// 直接取第一個，若無資料會丟null
            //Product one3 = db.Product.FirstOrDefault(p => p.ProductId == id);
            //// 直接取第一個，若無資料或非一筆會丟例外
            //Product single = db.Product.Single(p => p.ProductId == id);
            //// 直接取第一個，若無資料則丟null，如果非一筆會丟例外
            //Product single2 = db.Product.SingleOrDefault(p => p.ProductId == id);

            return View(data);
        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Product product = new Product();

                product.ProductName = collection["ProductName"];
                product.Price = Convert.ToDecimal(collection["Price"]);
                product.Stock = Convert.ToDecimal(collection["Stock"]);
                product.Active = true;

                db.Product.Add(product);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateAll()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("c"));

            foreach (var item in data)
            {
                item.Price = item.Price * 2;
            }

            try
            {
                // 本身就是交易，若更新N筆，只要其中1筆失敗，這N筆都不會更新，換句話說就是會rollback。
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateStockAll()
        {
            var data = db.Product.Where(p => p.ProductName.StartsWith("c"));

            Random rnd = new Random();

            foreach (var item in data)
            {
                item.Stock = Convert.ToDecimal(rnd.Next((int)item.Stock / 2, (int)item.Stock));
            }

            try
            {
                // 本身就是交易，若更新N筆，只要其中1筆失敗，這N筆都不會更新，換句話說就是會rollback。
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var client = db.Client.Find(id);

            // 先刪除與Client內的Order相關的OrderLine資料
            foreach (var order in client.Order.ToList())
            {
                db.OrderLine.RemoveRange(order.OrderLine.ToList());
            }
            // 再刪除與Client相關的Order資料
            db.Order.RemoveRange(client.Order.ToList());
            // 最後，刪除Client 
            db.Client.Remove(client);


            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
