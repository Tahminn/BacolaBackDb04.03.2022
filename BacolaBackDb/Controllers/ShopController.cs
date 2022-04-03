using BacolaBackDb.Data;
using BacolaBackDb.Models.Home;
using BacolaBackDb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Shop";
            ViewBag.Javascript = "shop";
            List<Product> products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .OrderByDescending(m => m.Id)
                .ToListAsync();
            List<Category> categories = await _context.Categories
                .Where(p => p.IsDeleted == false)
                .ToListAsync();
            List<Slider> sliders = await _context.Sliders
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            if (Request.Cookies["basket"] != null)
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories,
                    Sliders = sliders,
                    BasketVM = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
                };
                return View(homeVM);
            }
            else
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories,
                    Sliders = sliders
                };
                return View(homeVM);
            }
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
