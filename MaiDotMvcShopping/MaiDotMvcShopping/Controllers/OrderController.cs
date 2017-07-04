using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace MaiDotMvcShopping.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.OrderModel.Ship model)
        {
            if (this.ModelState.IsValid)
            {
                // 取得目前購物車
                var CurrentCart = Models.Carts.Operation.GetCurrentCart();

                // 取得目前登入使用者 Id
                var UserId = HttpContext.User.Identity.GetUserId();

                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    // 建立 Order 物件
                    var order = new Models.Order()
                    {
                        UserId = UserId,
                        ReceiverName = model.ReceiverName,
                        ReceiverPhone = model.ReceiverPhone,
                        ReceiverAddress = model.ReceiverAddress
                    };

                    // 加入 Order 資料表後，儲存變更
                    db.Orders.Add(order);
                    db.SaveChanges();

                    // 取得購物車中的 OrderDetail 物件
                    var orderDetails = CurrentCart.ToOrderDetailList(order.Id);

                    // 將 OrderDetail 物件，加入 OrderDetail 資料表後，儲存變更。
                    db.OrderDetails.AddRange(orderDetails);
                    db.SaveChanges();
                }
                return Content("訂購成功");
            }
            return View();
        }
    }
}