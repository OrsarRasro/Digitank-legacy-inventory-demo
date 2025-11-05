using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Legacy Entity Framework 6 DbContext - typical .NET Framework 4.5 implementation
    /// Shows outdated data access patterns and limited performance
    /// </summary>
    public class InventoryContext : DbContext
    {
        // Legacy connection string approach - hardcoded, not configurable
        public InventoryContext() : base("DefaultConnection")
        {
            // Legacy: Disable lazy loading for "performance" - actually causes N+1 problems
            Configuration.LazyLoadingEnabled = false;
            
            // Legacy: Disable proxy creation - limits EF functionality
            Configuration.ProxyCreationEnabled = false;
            
            // Legacy: Auto-detect changes enabled - performance impact
            Configuration.AutoDetectChangesEnabled = true;
            
            // Legacy database initialization - not recommended for production
            Database.SetInitializer(new CreateDatabaseIfNotExists<InventoryContext>());
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Legacy: Remove pluralizing table name convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Legacy: Configure Product entity with old-style fluent API
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Category)
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(p => p.Supplier)
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }

        // Legacy method - synchronous database operations only
        public void SeedData()
        {
            if (!Products.Any())
            {
                Products.Add(new Product
                {
                    ProductName = "Legacy Laptop",
                    Description = "Old Windows-only laptop",
                    Price = 999.99m,
                    StockQuantity = 15,
                    Category = "Electronics",
                    Supplier = "TechCorp",
                    CreatedDate = DateTime.Now
                });

                Products.Add(new Product
                {
                    ProductName = "Legacy Software License",
                    Description = "Windows-only software license",
                    Price = 299.99m,
                    StockQuantity = 50,
                    Category = "Software",
                    Supplier = "SoftwareCorp",
                    CreatedDate = DateTime.Now
                });

                Products.Add(new Product
                {
                    ProductName = "Legacy Server",
                    Description = "Windows Server 2012 R2",
                    Price = 2999.99m,
                    StockQuantity = 5,
                    Category = "Hardware",
                    Supplier = "ServerCorp",
                    CreatedDate = DateTime.Now
                });

                SaveChanges();
            }
        }

        // Legacy: Override SaveChanges without async support
        public override int SaveChanges()
        {
            // Legacy: Manual audit trail implementation
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Product && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var product = (Product)entry.Entity;
                
                if (entry.State == EntityState.Added)
                {
                    product.CreatedDate = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    product.LastUpdated = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        // Legacy: No proper disposal pattern
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Legacy: Basic disposal without proper resource management
                base.Dispose(disposing);
            }
        }
    }
}