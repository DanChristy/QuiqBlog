using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.AdminViewModels;
using QuiqBlog.Service.Interfaces;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers {
    public class AdminBusinessManager : IAdminBusinessManager {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostService postService;
        private readonly IUserService userService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminBusinessManager(
            UserManager<ApplicationUser> userManager,
            IPostService postService,
            IUserService userService,
            IWebHostEnvironment webHostEnvironment) {
            this.userManager = userManager;
            this.postService = postService;
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal) {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel {
                Posts = postService.GetPosts(applicationUser)
            };
        }

        public async Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal) {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new AboutViewModel {
                ApplicationUser = applicationUser,
                SubHeader = applicationUser.SubHeader,
                Content = applicationUser.AboutContent
            };
        }

        public async Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal) {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);

            applicationUser.SubHeader = aboutViewModel.SubHeader;
            applicationUser.AboutContent = aboutViewModel.Content;

            if (aboutViewModel.HeaderImage != null) {
                string webRootPath = webHostEnvironment.WebRootPath;
                string pathToImage = $@"{webRootPath}\UserFiles\Users\{applicationUser.Id}\HeaderImage.jpg";

                EnsureFolder(pathToImage);

                using (var fileStream = new FileStream(pathToImage, FileMode.Create)) {
                    await aboutViewModel.HeaderImage.CopyToAsync(fileStream);
                }
            }

            await userService.Update(applicationUser);
        }

        private void EnsureFolder(string path) {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0) {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}