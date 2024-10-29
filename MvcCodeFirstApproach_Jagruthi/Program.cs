using Microsoft.EntityFrameworkCore;
using MvcCodeFirstApproach_Jagruthi.Models;

namespace MvcCodeFirstApproach_Jagruthi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var ConnStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<EmployeeDBContext>(options => options.UseSqlServer(ConnStr));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=EmployeeModels}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
