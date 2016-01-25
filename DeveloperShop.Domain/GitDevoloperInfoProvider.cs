using DeveloperShop.Domain.Entities;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperShop.Domain
{
    public class GitApiProxy
    {
        private readonly GitHubClient _gitHubClient;

        public GitApiProxy(GitHubClient gitHubClient = null)
        {
            _gitHubClient = gitHubClient ?? new GitHubClient(new ProductHeaderValue("DeveloperShop"));
        }

        public async Task<Developer> GetDeveloperInfo(string username)
        {
            try
            {
                var gitHubClient = new GitHubClient(new ProductHeaderValue("DeveloperShop"));
                var userInfo = await gitHubClient.User.Get(username);
                return new Developer
                {
                    Avatar = userInfo.AvatarUrl,
                    Username = userInfo.Login,
                    Followers = userInfo.Followers
                    //Stars = _gitHubClient.Repository.GetAllForUser(username).Result.Sum(x => x.StargazersCount),
                    //Watchers = _gitHubClient.Activity.Watching.GetAllForUser(username).Result.Count
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async virtual Task<IEnumerable<Developer>> GetDevelopersFromOrganization(string organizationName)
        {
            var connection = new Connection(new ProductHeaderValue("DeveloperShop"));
            var orgMembers = new OrganizationMembersClient(new ApiConnection(connection));
            var orgDevs = await orgMembers.GetAll(organizationName);
            return orgDevs.Select(x => new Developer { Avatar = x.AvatarUrl, Username = x.Login}).ToList();
            //return orgDevs.Select(x => GetDeveloperInfo(x.Login).Result);
        }
    }
}
