using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebViewForm
{
    internal class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddRouting();
            return services.BuildServiceProvider();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseForwardedHeaders();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}"
                );
            });
        }
    }
}