using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace QuiqBlog.Configuration {
    public static class AppConfiguration {
        public static void AddDefaultConfiguration(this IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment) {
            if (webHostEnvironment.IsDevelopment()) {
                applicationBuilder.UseDatabaseErrorPage();
            } else {
                applicationBuilder.UseDeveloperExceptionPage();
                //applicationBuilder.UseExceptionHandler("/Home/Error");
                applicationBuilder.UseHsts();
            }
            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseRouting();

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}