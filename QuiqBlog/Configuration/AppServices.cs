using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuiqBlog.Data;
using QuiqBlog.Data.Models;

namespace QuiqBlog.Configuration {
    public static class AppServices {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration Configuration) {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            serviceCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            serviceCollection.AddControllersWithViews().AddRazorRuntimeCompilation();
            serviceCollection.AddRazorPages();
        }
    }
}