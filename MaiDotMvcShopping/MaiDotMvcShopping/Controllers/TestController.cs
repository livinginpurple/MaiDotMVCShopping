using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    public class TestController : Controller
    {
        public ActionResult GetCart()
        {
            // 取得目前購物車
            var Cart = Models.Carts.Operation.GetCurrentCart();
            Cart.AddProduct(1);

            // 回傳目前購物車中的商品總價
            return Content($"目前購物車總共：{Cart.TotalAmount} 元");
        }
    }
}