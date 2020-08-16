using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuiqBlog.BusinessManagers.Interfaces;
using System.Threading.Tasks;

namespace QuiqBlog.Controllers {

    [Authorize]
    public class AdminController : Controller {
        private readonly IAdminBusinessManager adminBusinessManager;

        public AdminController(IAdminBusinessManager adminBusinessManager) {
            this.adminBusinessManager = adminBusinessManager;
        }

        public async Task<IActionResult> Index() {
            return View(await adminBusinessManager.GetAdminDashboard(User));
        }
    }
}