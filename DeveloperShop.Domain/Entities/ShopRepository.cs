using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShop.Domain.Entities
{
    public class ShopRepository
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
    }
}