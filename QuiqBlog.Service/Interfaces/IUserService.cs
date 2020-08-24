using QuiqBlog.Data.Models;
using System.Threading.Tasks;

namespace QuiqBlog.Service.Interfaces {
    public interface IUserService {
        Task<ApplicationUser> Update(ApplicationUser applicationUser);
    }
}