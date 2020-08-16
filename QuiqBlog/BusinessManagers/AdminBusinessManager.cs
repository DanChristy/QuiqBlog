using Microsoft.AspNetCore.Identity;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.AdminViewModels;
using QuiqBlog.Service.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers {
    public class AdminBusinessManager : IAdminBusinessManager {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogService;

        public AdminBusinessManager(
            UserManager<ApplicationUser> userManager,
            IBlogService blogService) {
            this.userManager = userManager;
            this.blogService = blogService;
        }

        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal) {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);

            return new IndexViewModel {
                Blogs = blogService.GetBlogs(applicationUser)
            };
        }
    }
}