using System;

namespace QuiqBlog.Data.Enums {
    [Flags]
    public enum Permission {
        Read,
        Edit,
        Delete
    }
}