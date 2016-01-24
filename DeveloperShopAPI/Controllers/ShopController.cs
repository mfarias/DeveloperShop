using DeveloperShop.Domain;
using DeveloperShop.Domain.Entities;
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
        static readonly ShopRepository repository = new ShopRepository();

        private GitApiProxy _gitProvider = new GitApiProxy();

        // GET shop
        public ShopCart GetShopCart()
        {
            return repository.GetShopCart();
        }

        // GET shop/devinfo/{username}
        public async Task<User> GetDeveloperInfo(string id)
        {
            var github = new GitHubClient(new ProductHeaderValue("DeveloperShop"));
            return await github.User.Get(id);
        }

        
        // GET api/shop/organization/{org}
        public async Task<IEnumerable<Developer>> GetDevelopersFromOrganization(string org)
        {
            return await _gitProvider.GetDevelopersFromOrganization(org);

            //var connection = new Connection(new ProductHeaderValue("DeveloperShop"));
            //var orgMembers = new OrganizationMembersClient(new ApiConnection(connection));
            //var devs = await orgMembers.GetAll(org);
            //return devs.Select(x => _gitProvider.GetDeveloperInfo(x.Login)).ToList();

            //return devs.Select(x => new Developer
            //{
            //    Avatar = x.AvatarUrl,
            //    Username = x.Login
            //}).ToList();
        }

        // POST api/shop/addtocart/{dev}/{hours}
        [HttpPost]
        public async Task<Developer[]> AddDeveloperToCart([FromBody] CartItem c)
        {
            var user = await GetDeveloperInfo(c.devuser);
            var dev = user.ConvertGitUserToDeveloper();
            dev.Hours = c.hours;
            repository.AddToCart(dev);
            return repository.GetShopCart().Developers.ToArray();
        }

    }

    public static class GitExtensions
    {
        public static Developer ConvertGitUserToDeveloper(this User self)
        {
            return new Developer
            {
                Avatar = self.AvatarUrl,
                Username = self.Login,
                Followers = self.Followers
            };
        }
    }

    public class CartItem
    {
        public object data { get; set; }
        public string devuser { get; set; }
        public int hours { get; set; }
    }
}