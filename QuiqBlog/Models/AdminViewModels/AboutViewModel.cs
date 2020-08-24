using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace QuiqBlog.Models.AdminViewModels {
    public class AboutViewModel {
        [Display(Name = "Header Image")]
        public IFormFile HeaderImage { get; set; }
        [Display(Name = "Sub-header")]
        public string SubHeader { get; set; }
        public string Content { get; set; }
    }
}