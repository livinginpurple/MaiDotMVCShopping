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
                // 取得所有 AspNetUsers 的資料，並放入 Models.ManageUser 模式中
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

            // 設定錯誤訊息
            TempData["ResultMessage"] = $"使用者 {id} 不存在，請重新操作。";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.ManageUser model)
        {
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = (from s in db.AspNetUsers
                              where s.Id == model.Id
                              select s).FirstOrDefault();

                if (result != default(Models.AspNetUsers))
                {
                    result.UserName = model.UserName;
                    result.Email = model.Email;

                    db.SaveChanges();

                    // 設定成功訊息
                    TempData["ResultMessage"] = $"使用者 {model.UserName} 成功編輯。";
                    return RedirectToAction("Index");
                }
            }

            // 設定錯誤訊息
            TempData["ResultMessage"] = $"使用者 {model.UserName} 不存在，請重新操作。";
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                // 設定錯誤訊息
                TempData["ResultMessage"] = $"使用者 {id} 不存在，請重新操作。";
                return RedirectToAction("Index");
            }

            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = db.AspNetUsers.Find(id);
                return View(result);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = db.AspNetUsers.Find(id);
                if (result != default(Models.AspNetUsers))
                {
                    db.AspNetUsers.Remove(result);

                    // 儲存所有變更
                    db.SaveChanges();

                    // 設定成功訊息，並導回 Index 頁面
                    TempData["ResultMessage"] = $"使用者 {result.UserName} 已成功刪除";
                    return RedirectToAction("Index");
                }

                // 如果沒有資料，顯示錯誤訊息，並將頁面導回 Index 頁面。
                TempData["ResultMessage"] = $"使用者 {id} 不存在，無法刪除，請重新操作。";
                return RedirectToAction("Index");
            }
        }
    }
}