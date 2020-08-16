using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Authorization;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data.Enums;
using QuiqBlog.Models.BlogViewModels;
using System.Threading.Tasks;

namespace QuiqBlog.Controllers {
    public class BlogController : Controller {

        private readonly IBlogBusinessManager blogBusinessManager;

        public BlogController(IBlogBusinessManager blogBusinessManager) {
            this.blogBusinessManager = blogBusinessManager;
        }

        public IActionResult Index() {
            return View();
        }

        [Authorize]
        public IActionResult Create() {
            return View(new CreateBlogViewModel());
        }

        [AuthorizePermission(Permission.Edit)]
        public IActionResult Edit(int id) {
            return View(blogBusinessManager.EditBlog(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel createBlogViewModel) {
            await blogBusinessManager.CreateBlog(createBlogViewModel, User);
            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel) {
            await blogBusinessManager.UpdateBlog(editViewModel, User);
            return RedirectToAction("Edit", new { editViewModel.Blog.Id });
        }
    }
}