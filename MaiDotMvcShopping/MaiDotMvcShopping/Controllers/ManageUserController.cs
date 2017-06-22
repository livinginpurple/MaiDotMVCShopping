using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiDotMvcShopping.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = db.AspNetUsers.Select(
                    s => new Models.ManageUser { Id = s.Id, UserName = s.UserName, Email = s.Email });
                return View(result.ToList());
            }
        }

        public ActionResult Edit(string id)
        {
            return View();
        }

        public ActionResult Edit(Models.ManageUser model)
        {
            return View();
        }
    }
}