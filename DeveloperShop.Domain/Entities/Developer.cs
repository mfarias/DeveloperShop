using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShop.Domain.Entities
{
    public class Developer
    {
        public string Avatar { get; set; }
        
        public string Username { get; set; }
        
        public int Hours { get; set; }

        public int Followers { get; set; }
        
        public int Stars { get; set; }
        
        public int Watchers { get; set; }

        public double Price
        {
            get
            {
                return 25.5d + (3 * Followers) + (2 * Stars ) + Watchers;
            }
        }
    }
}