using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;
using QuiqBlog.Service.Interfaces;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers {
    public class BlogBusinessManager : IBlogBusinessManager {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BlogBusinessManager(
            UserManager<ApplicationUser> userManager,
            IBlogService blogService,
            IWebHostEnvironment webHostEnvironment) {
            this.userManager = userManager;
            this.blogService = blogService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal) {
            Blog blog = createBlogViewModel.Blog;

            blog.Creator = await userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;
            blog.UpdatedOn = DateTime.Now;

            blog = await blogService.Add(blog);

            await SetBlogHeaderImage(createBlogViewModel.BlogHeaderImage, blog.Id);

            return blog;
        }

        public async Task<Blog> UpdateBlog(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal) {
            var currentBlog = blogService.GetBlog(editViewModel.Blog.Id);

            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);

            if (currentBlog.Creator != applicationUser)
                HttpContext

            currentBlog.Title = editViewModel.Blog.Title;
            currentBlog.Content = editViewModel.Blog.Content;
            currentBlog.Published = editViewModel.Blog.Published;
            currentBlog.UpdatedOn = DateTime.Now;

            if (editViewModel.BlogHeaderImage != null) {
                await SetBlogHeaderImage(editViewModel.BlogHeaderImage, editViewModel.Blog.Id);
            }

            return await blogService.Update(currentBlog);
        }

        public EditViewModel EditBlog(int blogId) {
            return new EditViewModel {
                Blog = blogService.GetBlog(blogId)
            };
        }

        private async Task SetBlogHeaderImage(IFormFile formFile, int blogId) {
            string webRootPath = webHostEnvironment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Blogs\{blogId}\HeaderImage.jpg";

            EnsureFolder(pathToImage);

            using (var fileStream = new FileStream(pathToImage, FileMode.Create)) {
                await formFile.CopyToAsync(fileStream);
            }
        }

        private void EnsureFolder(string path) {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0) {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}