using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuiqBlog.Configuration;

namespace QuiqBlog {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDefaultServices(Configuration);
            services.AddCustomServices();
            services.AddCustomAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.AddDefaultConfiguration(env);
        }
    }
}