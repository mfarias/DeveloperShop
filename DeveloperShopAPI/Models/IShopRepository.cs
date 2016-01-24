using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShopAPI.Models
{
    public interface IShopRepository: IDisposable
    {
        ShopCart GetShopCart();
        void AddToCart(Developer dev);
    }
}