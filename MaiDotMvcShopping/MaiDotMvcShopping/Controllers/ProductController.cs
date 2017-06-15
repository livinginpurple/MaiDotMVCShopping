using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            // 宣告 result 儲存商品列表
            List<Models.Product> result = new List<Models.Product>();

            // 使用 CartsEntities 類別，名稱為 db
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 使用 LINQ 語法，抓取 Table Products 在資料庫中所有資料
                result = (from s in db.Products select s).ToList();
            }
            // 將 result 傳送至 View
            return View(result);
        }

        /// <summary>
        /// 商品建立頁面
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 商品建立頁面－資料傳回處理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Models.Product model)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 將回傳的資料 model，加入到 Products
                db.Products.Add(model);

                // 儲存異動的資料
                db.SaveChanges();
            }
            return View();
        }
    }
}