using Microsoft.AspNetCore.Http;
using QuiqBlog.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace QuiqBlog.Models.BlogViewModels {
    public class EditViewModel {
        [Display(Name = "Header Image")]
        public IFormFile BlogHeaderImage { get; set; }
        public Blog Blog { get; set; }
    }
}