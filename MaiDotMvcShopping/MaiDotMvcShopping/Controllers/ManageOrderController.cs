using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    [Authorize]
    public class ManageOrderController : Controller
    {
        // GET: ManageOrder
        public ActionResult Index()
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 取得 Order 中所有資料。
                var result = db.Orders.Select(s => s).ToList();
                return View(result);
            }
        }

        public ActionResult Details(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                // 取得 OrderId 為傳入 id 的所有商品列表
                var result = db.OrderDetails
                    .Where(w => w.OrderId == id)
                    .Select(s => s).ToList();

                if (result.Any())
                {
                    return View(result);
                }

                // 如果商品數目為零，代表該訂單異常 (無商品)。導回商品列表。
                return RedirectToAction("Index");
            }
        }

        [ValidateAntiForgeryToken]
        public ActionResult SearchByUserName(string userName)
        {
            // 儲存查詢出來的 UserId
            string SearchUserId = null;
            using (Models.UserEntities db = new Models.UserEntities())
            {
                SearchUserId = db.AspNetUsers
                    .Where(w => w.UserName == userName)
                    .Select(s => s.Id).FirstOrDefault();
            }

            // 如果有存在 UserId
            if (!string.IsNullOrEmpty(SearchUserId))
            {
                // 將該 UserId 的所有訂單找出
                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    var result = db.Orders
                        .Where(w => w.UserId == SearchUserId)
                        .Select(s => s).ToList();

                    // 回傳 結果 至 Index 頁面
                    return View("Index", result);
                }
            }

            // 回傳 空結果 至 Index View
            return View("Index", new List<Models.Order>());
        }
    }
}