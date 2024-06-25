using ECommerceMVC.Data;
using ECommerceMVC.Helpers;
using ECommerceMVC.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Hshop2023Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("HShop"));
            });
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/KhachHang/DangNhap";
                options.AccessDeniedPath = "/AccessDenied";
            });
            //dang ki paypal
			builder.Services.AddSingleton(x => new PaypalClient(
		builder.Configuration["PaypalOptions:AppId"],
		builder.Configuration["PaypalOptions:AppSecret"],
		builder.Configuration["PaypalOptions:Mode"]
));
			//dang ki VnPay
			builder.Services.AddSingleton<IVnPayService, VnPayService>();



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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
