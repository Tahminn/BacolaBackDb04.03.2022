using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BacolaBackDb.Data;
using BacolaBackDb.Models.Home;

namespace BacolaBackDb.Areas.BacolaAdmin.Controllers
{
    [Area("BacolaAdmin")]
    public class DiscountBannersController : Controller
    {
        private readonly AppDbContext _context;

        public DiscountBannersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DiscountBanners.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountBanner = await _context.DiscountBanners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discountBanner == null)
            {
                return NotFound();
            }

            return View(discountBanner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Header,Name,DiscountType,ButtonColor,Id,IsDeleted")] DiscountBanner discountBanner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountBanner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discountBanner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountBanner = await _context.DiscountBanners.FindAsync(id);
            if (discountBanner == null)
            {
                return NotFound();
            }
            return View(discountBanner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Header,Name,DiscountType,ButtonColor,Id,IsDeleted")] DiscountBanner discountBanner)
        {
            if (id != discountBanner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountBanner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountBannerExists(discountBanner.Id))
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
            return View(discountBanner);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountBanner = await _context.DiscountBanners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discountBanner == null)
            {
                return NotFound();
            }

            return View(discountBanner);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountBanner = await _context.DiscountBanners.FindAsync(id);
            _context.DiscountBanners.Remove(discountBanner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountBannerExists(int id)
        {
            return _context.DiscountBanners.Any(e => e.Id == id);
        }
    }
}
