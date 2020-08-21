using Microsoft.AspNetCore.Mvc;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Models.PostViewModels;
using System.Threading.Tasks;

namespace QuiqBlog.Controllers {
    public class PostController : Controller {

        private readonly IPostBusinessManager postBusinessManager;

        public PostController(IPostBusinessManager postBusinessManager) {
            this.postBusinessManager = postBusinessManager;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Create() {
            return View(new CreateViewModel());
        }

        public async Task<IActionResult> Edit(int? id) {
            var actionResult = await postBusinessManager.GetEditViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createViewModel) {
            await postBusinessManager.CreatePost(createViewModel, User);
            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel) {
            var actionResult = await postBusinessManager.UpdatePost(editViewModel, User);

            if (actionResult.Result is null)
                return RedirectToAction("Edit", new { editViewModel.Post.Id });

            return actionResult.Result;
        }
    }
}