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
            var user = await github.User.Get(username);
            return user;
        }

        // GET api/shop/organization/{org}
        public async Task<List<Developer>> GetDevelopersFromOrganization(string org)
        {
            var connection = new Connection(new ProductHeaderValue("DeveloperShop"));
            var orgMembers = new OrganizationMembersClient(new ApiConnection(connection));
            var devs = await orgMembers.GetAll(org);
            return devs.Select(x => new Developer
            {
                Avatar = x.AvatarUrl,
                Username = x.Login,
                Price = Developer.SetDeveloperPrice(x.Collaborators, x.Followers, x.TotalPrivateRepos + x.PublicRepos, x.PrivateGists + x.PublicGists)
            }).ToList();
        }

        // POST api/shop/addtocart/{dev}/{hours}
        [HttpPost]
        public async Task<Developer[]> AddDeveloperToCart([FromBody] CartItem c)
        {
            var user = await GetDeveloperInfo(c.devuser);

            var dev = new Developer
            {
                Avatar = user.AvatarUrl,
                Hours = c.hours,
                Price = Developer.SetDeveloperPrice(user.Collaborators, user.Followers, user.TotalPrivateRepos + user.PublicRepos, user.PrivateGists + user.PublicGists),
                Username = user.Login
            };

            repository.AddToCart(dev);
            return repository.GetShopCart().Developers.ToArray();
        }

    }

    public class CartItem
    {
        public object data { get; set; }
        public string devuser { get; set; }
        public int hours { get; set; }
    }
}