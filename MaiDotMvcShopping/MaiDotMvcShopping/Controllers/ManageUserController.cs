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
                    s => new Models.ManageUser
                    {
                        Id = s.Id,
                        UserName = s.UserName,
                        Email = s.Email
                    });
                return View(result.ToList());
            }
        }

        public ActionResult Edit(string id)
        {
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = db.AspNetUsers.Where(w => w.Id == id)
                    .Select(s => new Models.ManageUser
                    {
                        Id = s.Id,
                        UserName = s.UserName,
                        Email = s.Email
                    }).FirstOrDefault();

                if (result != default(Models.ManageUser))
                {
                    return View(result);
                }
            }

            TempData["ResultMessage"] = $"使用者 {id} 不存在，請重新操作。";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Models.ManageUser model)
        {
            return View();
        }
    }
}