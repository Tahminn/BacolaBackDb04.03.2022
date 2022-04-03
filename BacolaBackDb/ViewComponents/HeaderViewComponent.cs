using BacolaBackDb.Data;
using BacolaBackDb.Models.Home;
using BacolaBackDb.Services;
using BacolaBackDb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;
        public HeaderViewComponent(LayoutService layoutService, AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int productCount = 0;
            if (Request.Cookies["basket"] != null)
            {
                List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                productCount = basket.Sum(m => m.Count);
            }
            else
            {
                productCount = 0;
            }

            ViewBag.Count = productCount;

            //Dictionary<string, string> settings = _layoutService.GetSettings();

            List<Product> products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .OrderByDescending(m => m.Id)
                .Take(20)
                .ToListAsync();
            List<Category> categories = await _context.Categories
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            if (Request.Cookies["basket"] != null)
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories,
                    BasketVM = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"])
                };
                return (await Task.FromResult(View(homeVM)));
            }
            else
            {
                HomeVM homeVM = new HomeVM
                {
                    Products = products,
                    Categories = categories
                };
                return (await Task.FromResult(View(homeVM)));
            }


        }
    }
}
