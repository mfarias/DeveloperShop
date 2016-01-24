using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperShopAPI.Models
{
    public class Developer
    {
        public string Avatar { get; set; }
        public string Username { get; set; }
        public double Price { get; set; }
        public int Hours { get; set; }



        public static double SetDeveloperPrice(int collaborators, int followers, int Repos, int Gists)
        {
            return 75.50;
        }
    }
}