﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    public class CartController : Controller
    {
        /// <summary>
        /// 取得目前購物車頁面
        /// </summary>
        /// <returns>回傳購物車頁面</returns>
        public ActionResult GetCart()
        {
            return PartialView("_CartPartial");
        }

        /// <summary>
        /// 將 Product 加入到購物車
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>回傳購物車頁面</returns>
        public ActionResult AddToCart(int id)
        {
            var CurrentCart = Models.Carts.Operation.GetCurrentCart();
            CurrentCart.AddProduct(id);
            return PartialView("_CartPartial");
        }

        /// <summary>
        /// 從購物車移除 Product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>回傳購物車頁面</returns>
        public ActionResult RemoveFromCart(int id)
        {
            var CurrentCart = Models.Carts.Operation.GetCurrentCart();
            CurrentCart.RemoveProduct(id);
            return PartialView("_CartPartial");
        }

        /// <summary>
        /// 清空購物車
        /// </summary>
        /// <returns>回傳購物車頁面</returns>
        public ActionResult ClearCart()
        {
            var CurrentCart = Models.Carts.Operation.GetCurrentCart();
            CurrentCart.ClearCart();
            return PartialView("_CartPartial");
        }
    }
}