using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammersBlog.Services.Extensions;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Mvc.AutoMapper.Profiles;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Mvc.Helpers.Concrete;

namespace ProgrammersBlog.Mvc
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; // bu kısımda iç içe(nested) olan objelerin birbirine referans verdiklerinde sorun yapmadan kullanmamızı sağlar. 
            });
            //her bir değişiklikte uygulamamızı tekrar derlemeden kaydettikten sonra görebileceğiz.(AddRazorRuntimeCompilation)
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile));// derlenme esnasında automapper'in buradaki sınıfları taramasını sağlıyor
            services.LoadMyServices(connectionString:Configuration.GetConnectionString("LocalDB"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/User/Login");
                options.LogoutPath = new PathString("/Admin/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy=CookieSecurePolicy.SameAsRequest,// politika http iler gelirse http ile https ile gelirse de https ile dönüş yapar always olması daha iyidir
                };
                options.SlidingExpiration = true;// kullanıcı siteye giriş yaptıktan sonra ona süre tanır 
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);//7 gün boyunca yeniden giriş yapmasına gerek yoktur.
                options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();//sitemizde bulunmayan bir sayfaya gitmek istediğimizde bize 404 hatası verecektir. 
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();// bizim static olarak eklemek istediğimiz image ,svg dosyaları flan oluyor.

            app.UseRouting();
            app.UseAuthentication();//kullanıcı kontrolü 
            app.UseAuthorization();// yetki kontrolü 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                        );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
