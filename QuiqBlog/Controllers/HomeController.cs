using Microsoft.AspNetCore.Mvc;
using QuiqBlog.BusinessManagers.Interfaces;

namespace QuiqBlog.Controllers {
    public class HomeController : Controller {
        private readonly IPostBusinessManager postBusinessManager;
        private readonly IHomeBusinessManager homeBusinessManager;

        public HomeController(
            IPostBusinessManager blogBusinessManager,
            IHomeBusinessManager homeBusinessManager) {
            this.postBusinessManager = blogBusinessManager;
            this.homeBusinessManager = homeBusinessManager;
        }

        [Route("/")]
        public IActionResult Index(string searchString, int? page) {
            return View(postBusinessManager.GetIndexViewModel(searchString, page));
        }

        public IActionResult Author(string authorId, string searchString, int? page) {
            var actionResult = homeBusinessManager.GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
    }
}