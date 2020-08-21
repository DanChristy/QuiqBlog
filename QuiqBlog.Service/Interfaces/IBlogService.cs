using QuiqBlog.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuiqBlog.Service.Interfaces {
    public interface IBlogService {
        Blog GetBlog(int blogId);
        IEnumerable<Blog> GetBlogs(string searchString);
        IEnumerable<Blog> GetBlogs(ApplicationUser applicationUser);
        Task<Blog> Add(Blog blog);
        Task<Blog> Update(Blog blog);
    }
}