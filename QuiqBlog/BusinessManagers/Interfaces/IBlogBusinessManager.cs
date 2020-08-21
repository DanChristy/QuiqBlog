using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;
using QuiqBlog.Models.HomeViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers.Interfaces {
    public interface IBlogBusinessManager {
        IndexViewModel GetIndexViewModel(string searchString, int? page);
        Task<Blog> CreateBlog(CreateViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> UpdateBlog(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);
        Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal);
    }
}