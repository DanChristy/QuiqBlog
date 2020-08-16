using QuiqBlog.Data.Models;
using QuiqBlog.Models.BlogViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers.Interfaces {
    public interface IBlogBusinessManager {
        Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);
        Task<Blog> UpdateBlog(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal);
        EditViewModel EditBlog(int blogId);
    }
}