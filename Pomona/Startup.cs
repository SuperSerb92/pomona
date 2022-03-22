using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.EF;
using DataAccessLayer.EF.Repositories;
using DBModel.Interfaces;
using DBModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomona.Interfaces;
using Pomona.Services;
using Pomona.SignalRChat.Hubs;
using Pomona.Extensions;
using DevExpress.AspNetCore;

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
            services.AddAutoMapper(typeof(Startup));
          
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

            services.AddScoped<IEmployeeRepostitory, EmployeeRepository>();
            services.AddScoped<IEmployeesService, EmployeeService>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IBuyerService, BuyerService>();

            services.AddScoped<IPackagingRepository, PackagingRepository>();
            services.AddScoped<IPackagingService, PackagingService>();

            services.AddScoped<IPlotRepository, PlotRepository>();
            services.AddScoped<IPlotService, PlotService>();

            services.AddScoped<IPlotListRepository, PlotListRepository>();
            services.AddScoped<IPlotListService, PlotListService>();

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();

            services.AddScoped<ICultureRepository, CultureRepository>();
            services.AddScoped<ICultureService, CultureService>();

            services.AddScoped<ICultureTypeRepository, CultureTypeRepository>();
            services.AddScoped<ICultureTypeService, CultureTypeService>();

            services.AddScoped<IBarCodeGeneratorRepository, BarCodeGeneratorRepository>();
            services.AddScoped<IBarCodeGeneratorService, BarCodeGeneratorService>();

            services.AddScoped<IWorkEvaluationRepository, WorkEvaluationRepository>();
            services.AddScoped<IWorkEvaluationService, WorkEvaluationService>();

            services.AddScoped<IControlorEmployeesRelationRepository, ControlorEmployeesRelationRepository>();
            services.AddScoped<IControlorEmployeesService, ControlorEmployeesRelationService>();

            services.AddScoped<ISummaryReportRepository, SummaryReportRepository>();
            services.AddScoped<ISummaryReportService, SummaryReportService>();

            services.AddScoped<IRepurchaseRepository, RepurchaseRepository>();
            services.AddScoped<IRepurchaseService, RepurchaseService>();

            services.AddScoped<IProfitLossReportRepository, ProfitLossReportRepository>();
            services.AddScoped<IProfitLossReportService, ProfitLossReportService>();

            services.AddScoped<ISummaryRepurchaseRepository, SummaryRepurchaseRepository>();
            services.AddScoped<ISummaryRepurchaseService, SummaryRepurchaseService>();

            //services.AddMvc();

            services.AddMvc().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;

            });
            services.AddCors(options => {
                options.AddPolicy("AllowCorsPolicy", builder => {
                    // Allow all ports on local host.
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                    builder.WithHeaders("Content-Type");
                });
            });
            services.AddDevExpressControls();
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
            app.UseDevExpressControls();
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
