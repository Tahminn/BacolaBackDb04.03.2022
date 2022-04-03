using BacolaBackDb.Models.Home;
using BacolaBackDb.Utilities.Pagination;
using BacolaBackDb.ViewModels.ProductVMs;
using System.Collections.Generic;

namespace BacolaBackDb.ViewModels
{
    public class ShopVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Pagination<ProductListVM> PaginatedProduct { get; set; }
    }
}
