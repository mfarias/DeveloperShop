using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShopAPI.Models
{
    public class ShopCart
    {
        public ShopCart()
        {
            Developers = new List<Developer>();
        }

        public List<Developer> Developers { get; set; }
    }
}