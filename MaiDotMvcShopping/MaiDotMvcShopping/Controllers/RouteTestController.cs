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
            //return Content("這是 Index");
            return View();
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