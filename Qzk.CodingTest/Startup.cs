using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qzk.CodingTest.Core.JustEat.Queries;
using Qzk.CodingTest.Core.JustEat.Queries.Impl;
using Qzk.CodingTest.Core.Services;
using Qzk.CodingTest.Core.Services.Impl;
using Qzk.CodingTest.Entities.Settings;

namespace Qzk.CodingTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<JustEatApiSettings>(Configuration.GetSection("JustEatApiSettings"));
            services.AddSingleton<IRestaurantsQueryService, RestaurantsQueryService>();
            services.AddSingleton<IJustEatQueryClient, JustEatQueryClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Restaurants}/{action=OpenRestaurants}/{criteria?}");
            });
        }
    }
}
