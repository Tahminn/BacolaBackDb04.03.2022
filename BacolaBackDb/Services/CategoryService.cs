using BacolaBackDb.Data;
using BacolaBackDb.Models.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BacolaBackDb.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetCategories()
        {
            try
            {
                List<Category> products = await _context.Categories
                        .Where(p => p.IsDeleted == false)
                        .OrderByDescending(p => p.Id)
                        .ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
