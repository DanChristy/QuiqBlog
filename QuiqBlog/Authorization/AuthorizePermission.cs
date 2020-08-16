using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using QuiqBlog.Data.Enums;
using QuiqBlog.Data.Models;
using QuiqBlog.Service;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Authorization {
    public class AuthorizePermission : AuthorizeAttribute, IAuthorizationFilter {
        public Permission Permission { get; set; }

        public AuthorizePermission(Permission permission) => Permission = permission;

        public void OnAuthorization(AuthorizationFilterContext context) {
            var blogService = context.HttpContext.RequestServices.GetService(typeof(IBlogService)) as BlogService;
            var userManager = context.HttpContext.RequestServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;

            var blog = blogService.GetBlog(int.Parse((string)context.RouteData.Values["id"]));
            var applicationUser = userManager.GetUserAsync(context.HttpContext.User).Result;

            if (((Permission & Permission.Edit | Permission.Delete) != 0) && blog.Creator != applicationUser)
                context.Result = new UnauthorizedResult();
        }
    }
}