using Microsoft.AspNetCore.Mvc;
using QuiqBlog.BusinessManagers.Interfaces;
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

        public IActionResult Create() {
            return View(new CreateBlogViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel createBlogViewModel) {
            await blogBusinessManager.CreateBlog(createBlogViewModel, User);
            return RedirectToAction("Create");
        }
    }
}