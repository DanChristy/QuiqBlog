using QuiqBlog.Data.Models;
using System.Threading.Tasks;

namespace QuiqBlog.Service.Interfaces {
    public interface IBlogService {
        Task<Blog> Add(Blog blog);
    }
}