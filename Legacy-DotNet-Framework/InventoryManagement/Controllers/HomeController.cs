using System;
using System.Web.Mvc;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// Legacy Home Controller - typical .NET Framework 4.5 MVC implementation
    /// Shows outdated patterns, no async support, and poor error handling
    /// </summary>
    public class HomeController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // Legacy: No async support, blocking operations
        public ActionResult Index()
        {
            try
            {
                // Legacy: Seed data on every request - inefficient
                db.SeedData();

                // Legacy: Get all products without pagination - performance issue
                var products = db.Products.ToList();
                
                // Legacy: Business logic in controller - should be in service layer
                var totalProducts = products.Count;
                var totalValue = products.Sum(p => p.Price * p.StockQuantity);
                var lowStockProducts = products.Where(p => p.IsLowStock()).Count();

                // Legacy: ViewBag usage instead of strongly-typed view models
                ViewBag.TotalProducts = totalProducts;
                ViewBag.TotalValue = totalValue.ToString("C");
                ViewBag.LowStockProducts = lowStockProducts;
                ViewBag.LastUpdated = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View(products);
            }
            catch (Exception ex)
            {
                // Legacy: Poor error handling - exposes internal details
                ViewBag.Error = "Database error: " + ex.Message;
                return View("Error");
            }
        }

        // Legacy: About page with hardcoded information
        public ActionResult About()
        {
            ViewBag.Message = "Legacy Inventory Management System";
            ViewBag.Version = "1.0 (.NET Framework 4.5)";
            ViewBag.Platform = "Windows Only";
            ViewBag.Database = "SQL Server (Entity Framework 6)";
            ViewBag.Limitations = "No mobile support, Windows licensing required, limited scalability";

            return View();
        }

        // Legacy: Contact page - static information
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Information";
            ViewBag.Email = "support@legacysystem.com";
            ViewBag.Phone = "1-800-LEGACY";
            ViewBag.SupportHours = "Monday-Friday 9AM-5PM EST";

            return View();
        }

        // Legacy: System info action - exposes internal details
        public ActionResult SystemInfo()
        {
            try
            {
                ViewBag.ServerTime = DateTime.Now.ToString("F");
                ViewBag.MachineName = Environment.MachineName;
                ViewBag.OSVersion = Environment.OSVersion.ToString();
                ViewBag.DotNetVersion = Environment.Version.ToString();
                ViewBag.ProcessorCount = Environment.ProcessorCount;
                ViewBag.WorkingSet = Environment.WorkingSet.ToString("N0");

                // Legacy: Direct database connection info - security risk
                ViewBag.ConnectionString = db.Database.Connection.ConnectionString;
                ViewBag.DatabaseExists = db.Database.Exists();

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        // Legacy: No proper disposal pattern
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Legacy: Basic disposal without null checks
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}