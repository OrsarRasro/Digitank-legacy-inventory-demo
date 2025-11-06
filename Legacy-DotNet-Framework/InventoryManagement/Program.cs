
using System;
using System.Data.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InventoryManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure connection string from Web.config equivalent
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? "Data Source=.\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True";

            // Configure Entity Framework 6 connection string
            System.Data.Entity.Database.DefaultConnectionFactory =
                new System.Data.Entity.Infrastructure.SqlConnectionFactory(connectionString);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Configure request size limits (from httpRuntime maxRequestLength)
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 4096 * 1024; // 4096 KB from maxRequestLength
            });

            // Configure Entity Framework Database Initializer
            builder.Services.AddScoped<IDatabaseInitializer<Models.InventoryContext>>(provider =>
                new CreateDatabaseIfNotExists<Models.InventoryContext>());

            var app = builder.Build();
            // Initialize Entity Framework Database
using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<IDatabaseInitializer<Models.InventoryContext>>();
                Database.SetInitializer(initializer);
            }

            // Initialize Entity Framework Database
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
                name: "Default",
                pattern: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = "" });

            app.Run();
        }
    }
}