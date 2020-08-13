using Microsoft.AspNetCore.Mvc;

namespace QuiqBlog.Controllers {
    public class AdminController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}