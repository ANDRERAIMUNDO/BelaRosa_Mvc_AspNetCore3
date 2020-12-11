using BelaRosa_MVC_AspNetCore3_4.Models.Libres.Login;
using BelaRosa_MVC_AspNetCore3_4.Models.Libres.Middleware;
using BelaRosa_MVC_AspNetCore3_4.Models.Libres.Sessao;
using BelaRosa_MVC_AspNetCore3_4.Models.Repositories.Interfaces;
using BelaRosa_MVC_AspNetCore3_4.Models.Repositories;
using BelaRosa_MVC_AspNetCore3_4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


namespace BelaRosa_MVC_AspNetCore3_4
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
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddScoped<IColaborador, ColaboradorRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Sessao de configuração
            services.AddMemoryCache();//guardar os dados na memoria
            services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(15);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });
                services.AddScoped<Sessao>();
                services.AddScoped<LoginColaborador>();
                services.AddDistributedMemoryCache();
                services.AddMvc(options => options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x =>
                "O campo deve ser preenchido")).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
                services.AddDbContext<BelaRosaContext>(options => options.UseMySql(Configuration.GetConnectionString("BelaRosaContext")));
        }   
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
