using System;
using System.ComponentModel.DataAnnotations;

namespace MaiDotMvcShopping.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
        public class ProductMetaData
        {
            public int Id { get; set; }

            [Display(Name="商品名稱")]
            public string Name { get; set; }

            [Display(Name = "商品敘述")]
            public string Description { get; set; }

            [Display(Name = "分類代碼")]
            public int CategoryId { get; set; }

            [Display(Name = "商品價格")]
            public decimal Price { get; set; }

            [Display(Name = "發行日期")]
            public System.DateTime PublishDate { get; set; }

            [Display(Name = "商品狀態")]
            public bool Status { get; set; }

            [Display(Name = "商品圖片代碼")]
            public Nullable<long> DefaultImageId { get; set; }

            [Display(Name = "商品庫存數量")]
            public int Quantity { get; set; }
        }
    }
}