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

            // 接收 Create 傳來的成功訊息
            ViewBag.ResultMessage = TempData["ResultMessage"];

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
            if (!this.ModelState.IsValid) //如果資料驗證失敗
            {
                // 失敗訊息
                ViewBag.ResultMessage = "資料有誤，請檢查";

                // 停留在 Create 頁面，並保留原先填入資料。
                return View(model);
            }

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 將回傳的資料 model，加入到 Products
                db.Products.Add(model);

                // 儲存異動的資料
                db.SaveChanges();

                TempData["ResultMessage"] = $"商品{model.Name}成功建立";

                return RedirectToAction("Index");
            }

        }

        /// <summary>
        /// 編輯商品頁面
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ActionResult Edit(int id)
        {
            // 取得 Product.Id 等於輸入 id 的資料
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products
                              where s.Id == id
                              select s).FirstOrDefault();

                if (result != default(Models.Product)) // 判斷此 id 是否有資料
                {
                    return View(result); // 如果有資料，回傳編輯商品頁面
                }

                // 如果沒有資料，顯示錯誤訊息，並將頁面導回 Index 頁面。
                TempData["ResultMessage"] = "資料有誤，請重新操作";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// 編輯商品頁面－資料傳回處理
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Models.Product model)
        {
            if (!this.ModelState.IsValid)// 判斷使用者輸入的資料是否正確
            {
                // 資料不正確，則導回原頁面 (Edit 頁面)
                return View(model);
            }

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 取得 Product.Id 等於輸入 id 的資料
                var result = (from s in db.Products
                              where s.Id == model.Id
                              select s).FirstOrDefault();

                // 儲存使用者變更資料
                result.Name = model.Name;
                result.Description = model.Description;
                result.CategoryId = model.CategoryId;
                result.Price = model.Price;
                result.PublishDate = model.PublishDate;
                result.Status = model.Status;
                result.DefaultImageId = model.DefaultImageId;
                result.Quantity = model.Quantity;

                // 儲存所有變更
                db.SaveChanges();

                // 設定成功訊息，並導回 Index 頁面
                TempData["ResultMessage"] = $"商品{model.Name}已成功編輯";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// 刪除商品
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 取得 Product.Id 等於輸入 id 的資料
                var result = (from s in db.Products where s.Id == id select s).FirstOrDefault();
                if (result != default(Models.Product)) // 判斷此 id 是否有資料
                {
                    db.Products.Remove(result);

                    // 儲存所有變更
                    db.SaveChanges();

                    // 設定成功訊息，並導回 Index 頁面
                    TempData["ResultMessage"] = $"商品{result.Name}已成功刪除";
                    return RedirectToAction("Index");
                }

                // 如果沒有資料，顯示錯誤訊息，並將頁面導回 Index 頁面。
                TempData["ResultMessage"] = "指定資料不存在，無法刪除，請重新操作";
                return RedirectToAction("Index");
            }
        }

    }
}