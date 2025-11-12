
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace InventoryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add connection string from configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Register Entity Framework database initializer
            builder.Services.AddScoped<IDatabaseInitializer<Models.InventoryContext>>(provider =>
                new CreateDatabaseIfNotExists<Models.InventoryContext>());

            var app = builder.Build();

            // Configure Entity Framework database initialization
using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<IDatabaseInitializer<Models.InventoryContext>>();
                Database.SetInitializer(initializer);
            }

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
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