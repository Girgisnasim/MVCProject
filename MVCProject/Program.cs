using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
using MVCProject.Repositories;

namespace MVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BookContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

            builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<ITripsRepo, TripsRepo>();
            builder.Services.AddScoped<IPlanRepo, PlanRepo>();
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
