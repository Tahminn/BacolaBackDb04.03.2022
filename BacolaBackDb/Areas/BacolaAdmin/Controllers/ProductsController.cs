using BacolaBackDb.Data;
using BacolaBackDb.Models.Home;
using BacolaBackDb.Utilities.Pagination;
using BacolaBackDb.ViewModels;
using BacolaBackDb.ViewModels.ProductVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Areas.BacolaAdmin.Controllers
{
    [Area("BacolaAdmin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BacolaAdmin/Products
        public async Task<IActionResult> Index(string category, string price, string sortOrder, int after, int size, int page = 1)
        {
            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Date" : "Date-Desc";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "Price-Desc" : "Price";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "Name-Desc" : "Name";

            ViewData["ProductCount"] = await _context.Products.AsNoTracking().CountAsync() + 1;
            if (after == 0) after = (int)ViewData["ProductCount"];
            if (size == 0) size = 9;

            var products = await _context.Products
                .Where(x => x.Id < after)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .ToListAsync();
            if (category != null) products = products
                 .Where(p => p.Category.Name == category)
                 .ToList();
            string priceRange = price;
            //if (price != 0) products = products
            //     .Where(p => p.DiscountPrice = price)
            //     .ToList();
            //if (belowPrice != 0 && abovePrice == 0) products = products
            //     .Where(p => p.DiscountPrice <= belowPrice && p.DiscountPrice >= abovePrice)
            //     .ToList();
            int count = GetPageCount(products, size);
            switch (sortOrder)
            {
                case "Name":
                    products = products.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Name-Desc":
                    products = products.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Price":
                    products = products.OrderBy(s => s.DiscountPrice).ToList();
                    break;
                case "Price-Desc":
                    products = products.OrderByDescending(s => s.DiscountPrice).ToList();
                    break;
                case "Date":
                    products = products.OrderBy(s => s.Id).ToList();
                    break;
                default:
                    products = products.OrderByDescending(s => s.Id).ToList();
                    break;
            }
            products = products
                .Take(size)
                .ToList();

            //ViewData["SortOrder"] = String.IsNullOrEmpty(sortOrder) ? "Date-Desc" : sortOrder;
            ViewData["SortOrder"] = sortOrder;
            ViewData["Size"] = size;
            ViewData["Category"] = category;


            var productsVM = GetMapDatas(products);
            Pagination<ProductListVM> paginatedProduct = new Pagination<ProductListVM>(productsVM, page, count);
            List<Category> categories = await _context.Categories
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
            ShopVM shopVM = new ShopVM
            {
                PaginatedProduct = paginatedProduct,
                Categories = categories,
            };
            return View(shopVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ActualPrice,DiscountPrice,UnitsSold,UnitsQuantity,Rating,InStock,CategoryId,Id,IsDeleted")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ActualPrice,DiscountPrice,UnitsSold,UnitsQuantity,Rating,InStock,CategoryId,Id,IsDeleted")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: BacolaAdmin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private int GetPageCount(List<Product> products, int size)
        {
            var productCount = products.Count();
            return (int)Math.Ceiling((decimal)productCount / size);
        }
        private List<ProductListVM> GetMapDatas(List<Product> products)
        {
            List<ProductListVM> productLists = new List<ProductListVM>();
            foreach (Product product in products)
            {
                ProductListVM newProduct = new ProductListVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    ActualPrice = product.ActualPrice,
                    DiscountPrice = product.DiscountPrice,
                    UnitsSold = product.UnitsSold,
                    UnitsQuantity = product.UnitsQuantity,
                    Rating = product.Rating,
                    CategoryName = product.Category.Name,
                    Images = product.ProductImages
                        .Where(p => p.IsMain)
                        .FirstOrDefault()?
                        .Image
                };
                productLists.Add(newProduct);
            }
            return productLists;
        }

    }
}
