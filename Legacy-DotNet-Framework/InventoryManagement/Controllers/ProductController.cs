using System;
using System.Data.Entity;
using System.Linq;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace InventoryManagement.Controllers
{
    /// <summary>
    /// Legacy Product Controller - typical .NET Framework 4.5 MVC implementation
    /// Shows CRUD operations with outdated patterns and no async support
    /// </summary>
    public class ProductController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // Legacy: GET: Product - no async, no pagination
        public ActionResult Index()
        {
            try
            {
                // Legacy: Load all products at once - performance issue for large datasets
                var products = db.Products.ToList();

                // Legacy: Business logic in controller
                ViewBag.TotalProducts = products.Count;
                ViewBag.LowStockCount = products.Count(p => p.IsLowStock());
                ViewBag.TotalValue = products.Sum(p => p.Price * p.StockQuantity).ToString("C");

                return View(products);
            }
            catch (Exception ex)
            {
                // Legacy: Poor error handling
                TempData["Error"] = "Error loading products: " + ex.Message;
                return View(new Product[0]);
            }
        }

        // Legacy: GET: Product/Details/5 - no async
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // Legacy: Poor error handling
                return StatusCode((int)System.Net.HttpStatusCode.BadRequest);
            }

            // Legacy: Synchronous database call
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Legacy: Calculate related data in controller
            ViewBag.IsLowStock = product.IsLowStock();
            ViewBag.DiscountPrice = product.CalculateDiscountPrice();
            ViewBag.DisplayName = product.GetDisplayName();

            return View(product);
        }

        // Legacy: GET: Product/Create
        public ActionResult Create()
        {
            // Legacy: Hardcoded dropdown values - should come from database or configuration
            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Books",
                "Clothing",
                "Hardware",
                "Software"
            });

            ViewBag.Suppliers = new SelectList(new[]
            {
                "TechCorp",
                "BookWorld",
                "FashionPlus",
                "HardwarePro",
                "SoftwareCorp"
            });

            return View();
        }

        // Legacy: POST: Product/Create - no async, poor validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ProductId,ProductName,Description,Price,StockQuantity,Category,Supplier")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Legacy: Manual validation instead of using model validation
                    if (!product.IsValidForSale())
                    {
                        ModelState.AddModelError("", "Product is not valid for sale");
                        return View(product);
                    }

                    // Legacy: Set creation date manually
                    product.CreatedDate = DateTime.Now;

                    // Legacy: Synchronous database operations
                    db.Products.Add(product);
                    db.SaveChanges();

                    // Legacy: Simple success message
                    TempData["Success"] = "Product created successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Legacy: Catch-all exception handling
                ModelState.AddModelError("", "Error creating product: " + ex.Message);
            }

            // Legacy: Reload dropdown data on error - inefficient
            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Books",
                "Clothing",
                "Hardware",
                "Software"
            });

            ViewBag.Suppliers = new SelectList(new[]
            {
                "TechCorp",
                "BookWorld",
                "FashionPlus",
                "HardwarePro",
                "SoftwareCorp"
            });

            return View(product);
        }

        // Legacy: GET: Product/Edit/5 - no async
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)System.Net.HttpStatusCode.BadRequest);
            }

            // Legacy: Synchronous find operation
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            // Legacy: Reload dropdown data every time
            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Books",
                "Clothing",
                "Hardware",
                "Software"
            }, product.Category);

            ViewBag.Suppliers = new SelectList(new[]
            {
                "TechCorp",
                "BookWorld",
                "FashionPlus",
                "HardwarePro",
                "SoftwareCorp"
            }, product.Supplier);

            return View(product);
        }

        // Legacy: POST: Product/Edit/5 - no async, poor concurrency handling
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("ProductId,ProductName,Description,Price,StockQuantity,Category,Supplier,CreatedDate")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Legacy: Manual update tracking
                    product.LastUpdated = DateTime.Now;

                    // Legacy: Update entire entity - inefficient
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();

                    TempData["Success"] = "Product updated successfully!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating product: " + ex.Message);
            }

            // Legacy: Reload dropdown data on error
            ViewBag.Categories = new SelectList(new[]
            {
                "Electronics",
                "Books",
                "Clothing",
                "Hardware",
                "Software"
            }, product.Category);

            ViewBag.Suppliers = new SelectList(new[]
            {
                "TechCorp",
                "BookWorld",
                "FashionPlus",
                "HardwarePro",
                "SoftwareCorp"
            }, product.Supplier);

            return View(product);
        }

        // Legacy: GET: Product/Delete/5 - no async
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode((int)System.Net.HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Legacy: POST: Product/Delete/5 - no async, no soft delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                if (product != null)
                {
                    // Legacy: Hard delete - no audit trail
                    db.Products.Remove(product);
                    db.SaveChanges();
                    TempData["Success"] = "Product deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Product not found!";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error deleting product: " + ex.Message;
            }

            return RedirectToAction("Index");
        }

        // Legacy: No proper disposal pattern
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
