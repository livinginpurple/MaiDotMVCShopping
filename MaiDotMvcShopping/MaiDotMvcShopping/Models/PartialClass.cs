using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiDotMvcShopping.Models
{
    public class PartialClass
    {
    }

    /// <summary>
    /// 定義 Models.Order 的部分類別
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// 取得訂單中的使用者暱稱
        /// </summary>
        /// <returns>回傳 使用者暱稱</returns>
        public string GetUserName()
        {
            using (Models.UserEntities db = new UserEntities())
            {
                var result = db.AspNetUsers
                    .Where(w => w.Id == this.UserId)
                    .Select(s => s.UserName).FirstOrDefault();

                // 回傳找到的 UserName
                return result;
            }
        }
    }
}