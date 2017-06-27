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

            //
            if (Cart.cartItems.Any())
            {
                Cart.cartItems.First().Quantity += 1;
            }
            else
            {
                Cart.cartItems.Add(
                    new Models.Carts.CartItem()
                    {
                        Id = 1,
                        Name = "測試",
                        Quantity = 1,
                        Price = 100m
                    });
            }

            return Content($"目前購物車總共：{Cart.TotalAmount} 元");
        }
    }
}