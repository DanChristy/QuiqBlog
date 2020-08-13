using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuiqBlog.BusinessManagers;
using QuiqBlog.BusinessManagers.Interfaces;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;
using QuiqBlog.Service;
using QuiqBlog.Service.Interfaces;

namespace QuiqBlog.Configuration {
    public static class AppServices {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration Configuration) {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddRazorPages();
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IBlogBusinessManager, BlogBusinessManager>();

            serviceCollection.AddScoped<IBlogService, BlogService>();
        }
    }
}