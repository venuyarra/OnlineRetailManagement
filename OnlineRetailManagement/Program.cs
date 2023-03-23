using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineRetailManagement.Models;
using OnlineRetailManagement.Repository;

namespace OnlineRetailManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<OnlineRetaildbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DbCon")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                         .AddCookie(options => {
                             options.Cookie.Name = "MyCookie";
                             options.LoginPath = "/User/Login";
                             options.SlidingExpiration = false;

                         });
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAdminRepository,AdminRepository>();
            builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromSeconds(5));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");

            app.Run();
        }
    }
}