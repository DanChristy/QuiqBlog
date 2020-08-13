using Microsoft.AspNetCore.Identity;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;
using QuiqBlog.Service.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers {
    public class BlogBusinessManager : IBlogBusinessManager {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogService;

        public BlogBusinessManager(
            UserManager<ApplicationUser> userManager,
            IBlogService blogService) {
            this.userManager = userManager;
            this.blogService = blogService;
        }

        public async Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal) {
            Blog blog = createBlogViewModel.Blog;

            blog.Creator = await userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;

            return await blogService.Add(blog);
        }
    }
}