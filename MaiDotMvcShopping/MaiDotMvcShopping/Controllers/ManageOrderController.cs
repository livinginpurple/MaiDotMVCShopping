﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
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
    }
}