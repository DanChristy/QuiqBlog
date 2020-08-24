using QuiqBlog.Models.AdminViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuiqBlog.BusinessManagers.Interfaces {
    public interface IAdminBusinessManager {
        Task<IndexViewModel> GetAdminDashboard(ClaimsPrincipal claimsPrincipal);
        Task<AboutViewModel> GetAboutViewModel(ClaimsPrincipal claimsPrincipal);
        Task UpdateAbout(AboutViewModel aboutViewModel, ClaimsPrincipal claimsPrincipal);
    }
}