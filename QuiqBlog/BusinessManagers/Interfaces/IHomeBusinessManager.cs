using Microsoft.AspNetCore.Mvc;
using QuiqBlog.Models.HomeViewModels;

namespace QuiqBlog.BusinessManagers.Interfaces {
    public interface IHomeBusinessManager {
        ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page);
    }
}