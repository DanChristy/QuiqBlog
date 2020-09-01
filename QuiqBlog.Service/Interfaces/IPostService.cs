using QuiqBlog.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuiqBlog.Service.Interfaces {
    public interface IPostService {
        Post GetPost(int postId);
        IEnumerable<Post> GetPosts(string searchString);
        IEnumerable<Post> GetPosts(ApplicationUser applicationUser);
        Comment GetComment(int commentId);
        Task<Post> Add(Post post);
        Task<Comment> Add(Comment comment);
        Task<Post> Update(Post post);
    }
}