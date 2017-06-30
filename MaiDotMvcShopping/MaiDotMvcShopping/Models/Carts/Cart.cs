using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaiDotMvcShopping.Models.Carts
{
    /// <summary>
    /// 購物車類別
    /// </summary>
    [Serializable]
    public class Cart : IEnumerable<CartItem>
    {
        /// <summary>
        /// 儲存所有商品
        /// </summary>
        private List<CartItem> cartItems;

        /// <summary>
        /// 建構子 Initializes a new instance of the <see cref="Cart"/> class.
        /// </summary>
        public Cart()
        {
            this.cartItems = new List<CartItem>();
        }

        /// <summary>
        /// 取得購物車內商品的總數量
        /// </summary>
        public int Count
        {
            get { return this.cartItems.Count; }
        }
        /// <summary>
        /// 取得商品總價
        /// </summary>
        public decimal TotalAmount
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach (var cartItem in this.cartItems)
                {
                    totalAmount = totalAmount + cartItem.Amount;
                }
                return totalAmount;
            }
        }

        /// <summary>
        /// 新增一筆 Product
        /// </summary>
        /// <param name="product">Product 物件</param>
        /// <returns></returns>
        private bool AddProduct(Product product)
        {
            // 將 Product 轉換為 CartItem
            var cartItem = new Models.Carts.CartItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = 1
            };

            // 將 CartItem 加入到購物車
            this.cartItems.Add(cartItem);
            return true;
        }

        /// <summary>
        /// 新增一筆Product
        /// </summary>
        /// <param name="productId">ProductId</param>
        /// <returns></returns>
        public bool AddProduct(int productId)
        {
            var FindItem = this.cartItems.Where(w => w.Id == productId)
                .Select(s => s).FirstOrDefault();

            // 判斷相同 Id 的 CartItem 是否已經存在購物車內
            if (FindItem == default(Models.Carts.CartItem))
            {
                // 若不存在於購物車內，則新增一筆
                using (Models.CartsEntities db = new CartsEntities())
                {
                    var product = db.Products.Where(w => w.Id == productId)
                        .Select(s => s).FirstOrDefault();

                    if (product != default(Models.Product))
                    {
                        this.AddProduct(product);
                    }
                }
            }
            else
            {
                // 存在於購物車，則將商品數量累加
                FindItem.Quantity += 1;
            }
            return true;
        }

        /// <summary>
        /// 移除一筆 Product
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public bool RemoveProduct(int productId)
        {
            var FindItem = this.cartItems.Where(w => w.Id == productId)
                .Select(s => s).FirstOrDefault();

            // 判斷相同 Id 的 CartItem 是否已經存在購物車內
            if (FindItem != default(Models.Carts.CartItem))
            {
                // 存在於購物車內，將商品移除
                this.cartItems.Remove(FindItem);
            }

            return true;
        }

        public IEnumerator<CartItem> GetEnumerator()
        {
            return ((IEnumerable<CartItem>)cartItems).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<CartItem>)cartItems).GetEnumerator();
        }
    }
}