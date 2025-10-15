using Core.Interfaces;
using InfraStructure.Data;
using InfraStructure.Repositories;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace TaskMangmentSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TaskMangDbContext>(Options =>
            { Options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
