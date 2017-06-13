using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiDotMvcShopping.Models.RouteTest
{
    /// <summary>
    /// 商品模型類別
    /// </summary>
    public class TempProduct
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 取得目前所有商品的方法
        /// </summary>
        /// <returns></returns>
        public static List<TempProduct> GetAllProducts()
        {
            // 初始化商品列表
            List<TempProduct> productionList = new List<TempProduct>();

            // 加入三項商品
            productionList.Add(new MaiDotMvcShopping.Models.RouteTest.TempProduct
            {
                Id = 1,
                Name = "自動鉛筆",
                Price = 30.0m,
            });

            productionList.Add(new MaiDotMvcShopping.Models.RouteTest.TempProduct
            {
                Id = 2,
                Name = "記事本",
                Price = 50.0m,
            });

            productionList.Add(new MaiDotMvcShopping.Models.RouteTest.TempProduct
            {
                Id = 3,
                Name = "橡皮擦",
                Price = 10.0m,
            });

            return productionList;
        }
    }
}