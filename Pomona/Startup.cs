using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBModel.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomona.SignalRChat.Hubs;

namespace Pomona
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
            services.AddDbContext<DbModelContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Pomona"));
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddDistributedMemoryCache();

            services.AddSignalR();
           // services.AddSession();

            services.AddSession(opt =>
            {
                opt.Cookie.IsEssential = true;
            });

            //services.AddSession(o => o.Cookie.IsEssential = true);

            services
                .AddMemoryCache()
                .AddSession(s => {
                    s.Cookie.Name = "Pomona";
                    s.Cookie.IsEssential = true;
                    s.Cookie.HttpOnly = true;
                });

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvc();

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
              // app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseStaticFiles();
            app.UseSession();
          
          Session.AppContext.Configure(app.ApplicationServices
                      .GetRequiredService<IHttpContextAccessor>(), app.ApplicationServices
                      .GetRequiredService<IMemoryCache>());

            Session.HostEnvironment.Configure(env);

            app.UseMvc(routes =>
            {
                string guid = Guid.NewGuid().ToString();
                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{guid=" + guid + "}/{id?}");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {            
                endpoints.MapHub<ChatHub>("/chathub");
            });          
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Add framework services.
        //    services
        //        .AddControllersWithViews()
        //        .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //    }
        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints => {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Login}/{action=Login}/{id?}");
        //    });
        //}
    }
}
