using QuiqBlog.Data.Models;

namespace QuiqBlog.Models.PostViewModels {
    public class PostViewModel {
        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}