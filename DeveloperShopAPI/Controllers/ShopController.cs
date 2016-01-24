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
        static readonly IShopRepository repository = new ShopRepository();

        // GET api/shop
        public ShopCart GetShopCart()
        {
            return repository.GetShopCart();
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
            return devs.Select(x => new Developer { 
                Avatar = x.AvatarUrl, 
                Username = x.Login,
                Price = Developer.SetDeveloperPrice(x.Collaborators, x.Followers, x.TotalPrivateRepos + x.PublicRepos, x.PrivateGists + x.PublicGists)
            }).ToList();
        }

        // POST api/shop/addtocart/{dev}/{hours}
        public void AddDeveloperToCart(string devuser, int hours)
        {
            Task<User> taskDev = GetDeveloperInfo(devuser);
            User dev = taskDev.Result;
            repository.AddToCart(new Developer
            {
                Avatar = dev.AvatarUrl,
                Hours = hours,
                Price = Developer.SetDeveloperPrice(dev.Collaborators, dev.Followers, dev.TotalPrivateRepos + dev.PublicRepos, dev.PrivateGists + dev.PublicGists),
                Username = dev.Login
            });
        }

    }
}