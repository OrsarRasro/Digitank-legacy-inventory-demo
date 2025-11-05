using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    /// <summary>
    /// Legacy Product model - typical .NET Framework 4.5 implementation
    /// Shows outdated patterns and limited functionality
    /// </summary>
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        [Range(0.01, 999999.99)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Supplier { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdated { get; set; }

        // Legacy business logic - should be in service layer
        public bool IsLowStock()
        {
            return StockQuantity < 10;
        }

        // Legacy method - inefficient string concatenation
        public string GetDisplayName()
        {
            return ProductName + " - " + Category + " ($" + Price.ToString() + ")";
        }

        // Legacy validation - should use modern validation attributes
        public bool IsValidForSale()
        {
            if (string.IsNullOrEmpty(ProductName))
                return false;
            if (Price <= 0)
                return false;
            if (StockQuantity < 0)
                return false;
            return true;
        }

        // Legacy method - hardcoded business rules
        public decimal CalculateDiscountPrice()
        {
            // Hardcoded 10% discount for electronics - should be configurable
            if (Category == "Electronics")
                return Price * 0.9m;
            
            // Hardcoded 5% discount for books - should be configurable
            if (Category == "Books")
                return Price * 0.95m;
            
            return Price;
        }

        // Legacy method - no async support
        public void UpdateStock(int quantity)
        {
            StockQuantity = quantity;
            LastUpdated = DateTime.Now;
            
            // Legacy logging - should use proper logging framework
            System.Diagnostics.Debug.WriteLine($"Stock updated for {ProductName}: {quantity}");
        }
    }
}