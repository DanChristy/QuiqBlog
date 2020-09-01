using System;
using System.Collections.Generic;

namespace QuiqBlog.Data.Models {
    public class Comment {
        public int Id { get; set; }

        public Post Post { get; set; }
        public ApplicationUser Author { get; set; }
        public string Content { get; set; }
        public Comment Parent { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}