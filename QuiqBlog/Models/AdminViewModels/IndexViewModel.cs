using QuiqBlog.Data.Models;
using System.Collections.Generic;

namespace QuiqBlog.Models.AdminViewModels {
    public class IndexViewModel {
        public IEnumerable<Post> Posts { get; set; }
    }
}