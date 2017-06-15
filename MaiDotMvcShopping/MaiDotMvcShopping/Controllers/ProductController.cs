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
    }
}