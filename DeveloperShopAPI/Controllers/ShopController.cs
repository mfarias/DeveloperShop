using DeveloperShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Octokit;
using System.Web.Http.Cors;

namespace DeveloperShopAPI.Controllers
{
    public class ShopController : ApiController
    {
        // GET api/shop
        public ShopCart GetShopCart()
        {
            ShopCart shop = new ShopCart();
            shop.Developers = new List<Developer>();
            shop.Developers.Add(new Developer() { Username = "mfarias" });
            shop.Developers.Add(new Developer() { Username = "lfernandes" });
            return shop;
        }

        // GET api/shop/devinfo/{username}
        public async Task<User> GetDeveloperInfo(string username)
        {
            var github = new GitHubClient(new ProductHeaderValue("DeveloperShop"));
            var user = await github.User.Get("mfarias");
            return user;
        }

        // GET api/shop/organization/{org}
        public async Task<List<Developer>> GetDevelopersFromOrganization(string org)
        {
            var connection = new Connection(new ProductHeaderValue("DeveloperShop"));
            var orgMembers = new OrganizationMembersClient(new ApiConnection(connection));
            var devs = await orgMembers.GetAll(org);
            return devs.Select(x => new Developer { Avatar = x.AvatarUrl, Username = x.Login }).ToList();
        }

        // PUT api/values/dev
        public void AddDeveloperToCart(string dev)
        {

        }

    }
}