using Microsoft.AspNetCore.Identity;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.AdminViewModels;
using QuiqBlog.Service.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers {
    public class AdminBusinessManager : IAdminBusinessManager {
        private UserManager<ApplicationUser> userManager;
        private IPostService postService;

        public AdminBusinessManager(
            UserManager<ApplicationUser> userManager,
            IPostService postService) {
            this.userManager = userManager;
            this.postService = postService;
        }

        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal) {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel {
                Posts = postService.GetPosts(applicationUser)
            };
        }
    }
}