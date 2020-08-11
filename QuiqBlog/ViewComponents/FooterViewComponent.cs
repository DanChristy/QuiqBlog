using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace QuiqBlog.ViewComponents {
    public class FooterViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync() {
            return await Task.Factory.StartNew(() => { return View(); });
        }
    }
}