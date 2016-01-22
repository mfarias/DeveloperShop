using DeveloperShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Octokit;

namespace DeveloperShopAPI.Controllers
{
    public class ShopController : ApiController
    {
        // GET api/shop
        public ShopCart GetShopCart()
        {
            ShopCart shop = new ShopCart();
            shop.Developers = new List<Developer>();
            shop.Developers.Add(new Developer() { Name = "Marcela Farias", Username = "mfarias"});
            shop.Developers.Add(new Developer() { Name = "Luciano Fernandes", Username = "lfernandes" });
            return shop;
        }

        //// GET api/shop/devinfo/{username}
        //public string GetDeveloperInfo(string username)
        //{
        //    var github = new GitHubClient(new Octokit.ProductHeaderValue("MyAmazingApp"));
        //    var user = github.User.Get("mfarias");
        //    return "whatever";
        //}


        // POST api/values
        public void AddDeveloperToCart([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}