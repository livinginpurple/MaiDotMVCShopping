using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    public class RouteTestController : Controller
    {
        // GET: RouteTest
        public ActionResult Index()
        {
            // Team Explorer test
            // 取得所有商品，並放入 result
            var result = Models.RouteTest.TempProduct.GetAllProducts();

            // 將 result (所有商品) 傳送至 View
            return View(result);
        }

        // e.g. RouteTest/Index2?id=1
        public ActionResult Index2(string id)
        {
            return Content(
                $"id 的值為：{id}"
                );
        }

        // e.g. RouteTest/Index3?id=1&page=2
        public ActionResult Index3(string id, string page)
        {
            return Content(
                $"id 的值為：{id}，page 的值為：{page}"
                );
        }

        // e.g.: /RouteTest/Index4/4
        public ActionResult Index4(string id, string page)
        {
            return Content(
                $"id 的值為：{id}，page 的值為：{page}"
                );
        }

        // e.g.: /RouteTest/Index5/4
        [Route("RouteTest/{id}")]
        public ActionResult Index5(string id)
        {
            return Content(
                $"id 的值為：{id}"
                );
        }
    }
}