using System.Linq;
using System.Net;
using MyBlog.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Api.Mvc;
using MyBlog.CommandQuery.Queries;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace MyBlog.Api
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
            services.AddCors();

            ApplicationContext.Container = new Container();
            services.AddMvc(options => { options.Filters.Add(new UnitOfWorkAttribute()); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton(Configuration);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataContext>
            (options => options
                .UseSqlServer(connectionString).UseLazyLoadingProxies());

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            IntegrateSimpleInjector(services);
        }

        void IntegrateSimpleInjector(IServiceCollection services)
        {
            ApplicationContext.Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(ApplicationContext.Container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(ApplicationContext.Container));

            services.EnableSimpleInjectorCrossWiring(ApplicationContext.Container);
            services.UseSimpleInjectorAspNetRequestScoping(ApplicationContext.Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var origins = Configuration.GetSection("Appsettings:AllowedOriginSites").Get<string[]>();

            app.UseExceptionHandler(    
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins(origins));

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }

        static void RegisterCommandQueryNameSpace()
        {
            var registrations =
                from type in typeof(GetEntityByIdQuery).Assembly.GetExportedTypes()
                where type.Namespace.StartsWith("MyBlog.CommandQuery")
                where !type.Namespace.StartsWith("MyBlog.CommandQuery.Configuration")
                where type.GetInterfaces().Any()
                select new { Service = type.GetInterfaces().SingleOrDefault() ?? type, Implementation = type };

            foreach (var reg in registrations)
            {
                ApplicationContext.Container.Register(reg.Service, reg.Implementation);
            }
        }

        void InitializeContainer(IApplicationBuilder app)
        {
            RegisterCommandQueryNameSpace();

            ApplicationContext.Container.RegisterMvcControllers(app);

            ApplicationContext.Container.AutoCrossWireAspNetComponents(app);

            ApplicationContext.Container.Register<IDataContext, DataContext>(Lifestyle.Scoped);

            ApplicationContext.Container.Verify();
        }
    }
}
