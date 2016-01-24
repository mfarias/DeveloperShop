using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShopAPI.Models
{
    public class ShopRepository: IShopRepository
    {
        private ShopCart shopcart = new ShopCart();

        public ShopCart GetShopCart()
        {
            return shopcart;
        }

        public void AddToCart(Developer dev)
        {
            shopcart.Developers.Add(dev);
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}